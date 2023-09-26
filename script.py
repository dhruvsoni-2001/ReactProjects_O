[12:51 PM] Farhan Lodi

import time

import random

import pyautogui

 

# Initialize variables

key_to_hold = "a"

min_key_press_duration = 2

max_key_press_duration = 7 # Adjust the maximum duration to 15

mouse_hover_duration = 2

change_interval = 7 * 60  # Change settings every 7 minutes

last_change_time = time.time()

key_press_duration = min_key_press_duration  # Initialize key_press_duration

 

try:

    while True:

        current_time = time.time()

       

        # Check if it's time to change settings

        if current_time - last_change_time > change_interval:

            # Change key press duration randomly within the specified range

            key_press_duration = random.uniform(min_key_press_duration, max_key_press_duration)

            last_change_time = current_time  # Update last change time

       

        # Simulate holding down the key.

        pyautogui.keyDown(key_to_hold)

       

        # Simulate mouse hovering (move the mouse a small amount).

        pyautogui.move(1, 1)

       

        # Sleep for the specified duration.

        time.sleep(key_press_duration)

       

        # Release the key.

        pyautogui.keyUp(key_to_hold)

       

        print(f"Key Press Duration: {key_press_duration:.2f} seconds")

       

        # Sleep for a short interval (2 seconds) before the next iteration.

        time.sleep(mouse_hover_duration)

except KeyboardInterrupt:

    print("Script terminated.")

 