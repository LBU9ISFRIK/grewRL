import gym

from stable_baselines.common.policies import MlpPolicy
from stable_baselines.common.cmd_util import make_mujoco_env
#from stable_baselines.common.vec_env.vec_normalize import VecNormalize
from stable_baselines.common.vec_env import DummyVecEnv
from stable_baselines import PPO2

import pybullet_envs

#env = gym.make('CartPole-v1')
env = make_mujoco_env('AntBulletEnv-v0', seed=0)
#env = VecNormalize(env0, norm_obs = True, norm_reward = False)

#env = DummyVecEnv([lambda: AHUenv() for i in range(1)])
# Optional: PPO2 requires a vectorized environment to run
# the env is now wrapped automatically when passing it to the constructor
#env = DummyVecEnv([lambda: env])
model = PPO2(MlpPolicy, env, verbose=1)

model.learn(total_timesteps=500)
print("end training =========================================")
#obs = env.reset()
#for i in range(1000):
#    action, _states = model.predict(obs)
#    obs, rewards, dones, info = env.step(action)
#    env.render()

model.save("ppo2_cartpole")
print("saved model =========================================")
#env.close()

model = PPO2.load("ppo2_cartpole", env)
print("loaded model =========================================")

#env = make_mujoco_env('AntBulletEnv-v0', seed=0)
#env = DummyVecEnv([lambda: env])
#model.set_env(env)
model.learn(total_timesteps=500)