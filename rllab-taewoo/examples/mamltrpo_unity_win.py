from sandbox.rocky.tf.algos.maml_trpo import MAMLTRPO
from sandbox.rocky.tf.policies.maml_minimal_gauss_mlp_policy import MAMLGaussianMLPPolicy
from sandbox.rocky.tf.envs.base import TfEnv
    
from rllab.baselines.linear_feature_baseline import LinearFeatureBaseline
from rllab.envs.unity_env import UnityGymEnv
from rllab.envs.normalized_env import normalize
from rllab.misc.instrument import stub, run_experiment_lite

import sys
sys.path.append("../scripts")
from scripts.run_experiment_lite import run_experiment

import base64
import pickle as pickle
import tensorflow as tf


stub(globals())
    

#env = normalize(GymEnv("Pendulum-v0"))
env = normalize(UnityGymEnv(None))

if use_tf:
    env = TfEnv(env)
    policy = MAMLGaussianMLPPolicy(
        name="policy",
        env_spec=env.spec,
        grad_step_size=0.5,
        hidden_nonlinearity=tf.nn.relu,
        hidden_sizes=(100,100),
    )
else:
    policy = GaussianMLPPolicy(
        env_spec=env.spec,
        # The neural network policy should have two hidden layers, each with 32 hidden units.
        hidden_sizes=(32, 32)
    )

baseline = LinearFeatureBaseline(env_spec=env.spec)

algo = MAMLTRPO(
    env=env,
    policy=policy,
    baseline=baseline,
    max_path_length=env.horizon,
    batch_size=10, # number of trajs for grad update
    meta_batch_size=20,
    num_grad_updates=1,
    n_itr=100,
    use_maml=True,
    step_size=0.01,
    plot=False,
)
            


exp_name = "experiment_2020_09_03_21_30_47_0002"
dict = [
    "c:\\users\\kimtaewoo\\documents\\projects\\rllab-master\\scripts\\run_experiment_lite.py",
    "--n_parallel", "1",
    "--snapshot_mode", "last",
    "--seed", "1",
    "--exp_name", exp_name,
    "--log_dir" , "c:\\users\\kimtaewoo\\documents\\projects\\rllab-master\\data\\local\\experiment\\" + exp_name,
    "--use_cloudpickle", "False",
    "--args_data", base64.b64encode(pickle.dumps(algo.train())).decode("utf-8")
    ]
    
run_experiment(dict)

'''
run_experiment_lite(
    algo.train(),
    # Number of parallel workers for sampling
    n_parallel=1,
    # Only keep the snapshot parameters for the last iteration
    snapshot_mode="last",
    # Specifies the seed for the experiment. If this is not provided, a random seed
    # will be used
    seed=1,
    #plot=True,
)
'''