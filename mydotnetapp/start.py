import subprocess
from time import sleep

def start():
    # Replace 'your_executable' with the actual name or path of the executable
    executable = './mydotnetapp'

    # Replace 'arg1', 'arg2', etc. with the actual arguments your executable requires
    #arguments = ['localhost', 'DB_name', '/F']

    try:
        # Run the executable with arguments
        subprocess.run(executable)
        print('reached')
    except Exception as e:
        print(f"An error occurred: {e}")

if __name__ == '__main__':
    start()