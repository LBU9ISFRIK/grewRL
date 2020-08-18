import numpy as np
from dm_control import suite
from PIL import Image

import cv2
import os
import glob

env = suite.load(domain_name="humanoid", task_name='run')

action_spec = env.action_spec()
time_step = env.reset()
time_step_counter = 0

while not time_step.last() and time_step_counter < 500:
    action = np.random.uniform(action_spec.minimum,
                               action_spec.maximum,
                               size=action_spec.shape)

    time_step = env.step(action)

    image_data = env.physics.render(height=480, width=480, camera_id="back")
    #img = Image.fromarray(image_data, 'RGB')
    #image = np.array(img)
    cv2.imwrite('frames/humanoid-%.3d.jpg' % time_step_counter, image_data)

    time_step_counter += 1
    print(time_step.reward, time_step.discount, time_step.observation)

    img_array = []
    for filename in glob.glob('frames/*.jpg'):
        img = cv2.imread(filename)
        height, width, layers = img.shape
        size = (width, height)
        img_array.append(img)

    out = cv2.VideoWriter('project.avi', cv2.VideoWriter_fourcc(*'DIVX'), 15, size)

    for i in range(len(img_array)):
        out.write(cv2.cvtColor(img_array[i], cv2.COLOR_RGB2BGR))
    out.release()