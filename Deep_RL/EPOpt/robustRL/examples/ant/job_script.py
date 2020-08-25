"""
    A simple wrapper to call the training modules.
    Useful when you want to run multiple jobs together in the
    background of a compute node

    Aravind Rajeswaran, 08/04/16
"""

import logging
logging.disable(logging.CRITICAL)
import sys
sys.dont_write_bytecode = True
import os

from robustRL.algos import *
from robustRL.samplers import *
from robustRL.train_agent import *
from robustRL.utils import *
np.random.seed(10)
rllab_set_seed(10)

cwd = os.getcwd()

job_set = []
#data_file = open('job_data.txt', 'r')

with open (os.path.join(os.path.dirname(os.path.abspath(__file__)), 'job_data.txt'), 'rt') as data_file:

    for line in data_file:
        print(line)
        job_set.append(eval(line))


if __name__ == '__main__':
    t1 = timer.time()

    for job in job_set:
        print(" ============================================================")
        os.chdir(cwd)
        job_start_time = timer.time()
        print("Started New Job : ", job['job_id'])
        print("Job specifications : \n", job)
        train_agent(**job)
        print("Job took time = ", timer.time()-job_start_time)

    t2 = timer.time()
    print("Total time taken = ", t2-t1)
