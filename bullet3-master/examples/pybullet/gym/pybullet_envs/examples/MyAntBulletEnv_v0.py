#add parent dir to find package. Only needed for source code build, pip install doesn't need it.
import os
import inspect
currentdir = os.path.dirname(os.path.abspath(inspect.getfile(inspect.currentframe())))
parentdir = os.path.dirname(os.path.dirname(currentdir))
os.sys.path.insert(0, parentdir)
import gym
import numpy as np
import pybullet_envs
import time

import tensorflow as tf

from stable_baselines.common.policies import MlpPolicy
#from stable_baselines.common.vec_env import DummyVecEnv
from stable_baselines import PPO2

sess = tf.Session()

env = gym.make('AntBulletEnv-v0')

obs_dim = env.observation_space.shape[0]
act_dim = env.action_space.shape[0]

print("obs dim : ", env.observation_space)
print("act dim : ", env.action_space)

loadFileIndex = 2
loadFileString = "ppo2_pybulletAnt_end_{}".format(loadFileIndex)
saveFileString = "ppo2_pybulletAnt_end_{}".format(loadFileIndex + 1)

print("loadFile : ", loadFileString)
print("saveFile : ", saveFileString)

isTrain = False
isContinue = True
if isTrain:
  print("start training =========================================")

  if not isContinue:
    model = PPO2(MlpPolicy, env, verbose=1)
  else:
    print("load model =========================================")
    model = PPO2.load(loadFileString, env)

  model.learn(total_timesteps=100000)
  print("end training =========================================")
  
  model.save(saveFileString)
  print("saved model =========================================")
else:
  print("load model =========================================")
  model = PPO2.load(loadFileString, env)

  print("start test =========================================")

  env.render(mode="human")

  obs = env.reset()
  #time.sleep(3)
  #while 1:
  frame = 0
  score = 0
  restart_delay = 0
  obs = env.reset()
  done = False
  while not done:
    #action = np.random.randn(act_dim,1)
    #action = action.reshape((1,-1)).astype(np.float32)
  
    time.sleep(1. / 60.)
    #obs, reward, done, _ = env.step(np.squeeze(action, axis=0))
    action, _states = model.predict(obs)
    obs, reward, done, info = env.step(action)
    env.render()
  
    #obs, r, done, _ = env.step(env.action_space.sample())
    score += reward
    frame += 1
    #distance = 5
    #yaw = 0
    #still_open = env.render("human")
    #if not done: continue
    #if restart_delay == 0:
    #  print("score=%0.2f in %i frames" % (score, frame))
    #  restart_delay = 60 * 2  # 2 sec at 60 fps
    #else:
    #  restart_delay -= 1
    #  if restart_delay == 0: break
  print("score=%0.2f in %i frames" % (score, frame))
  env.close()