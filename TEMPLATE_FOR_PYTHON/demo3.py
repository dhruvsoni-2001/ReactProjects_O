import shutil
import os
import re

def rename_and_replace(src_dir, dst_dir, find, replace):
    # Create the destination directory if it doesn't exist
    if not os.path.exists(dst_dir):
        os.makedirs(dst_dir)

    for item in os.listdir(src_dir):
        s = os.path.join(src_dir, item)
        d = os.path.join(dst_dir, item)

        try:
            if os.path.isdir(s):
                # Generate a new folder name with find and replace
                new_folder_name = item.replace(find, replace)
                d = os.path.join(dst_dir, new_folder_name)
                shutil.copytree(s, d)
                # Recursively replace "find" with "replace" in folder names and file contents
                rename_and_replace(s, d, find, replace)
            else:
                # Rename files with "find" in their names to "replace"
                new_file_name = item.replace(find, replace)
                d = os.path.join(dst_dir, new_file_name)
                shutil.copy2(s, d)
                if s.endswith(".cs"):
                    # Replace "find" with "replace" in C# file content
                    with open(d, "r") as file:
                        file_data = file.read()
                    file_data = re.sub(r'\b' + re.escape(find) + r'\b', replace, file_data)
                    with open(d, "w") as file:
                        file.write(file_data)
        except Exception as e:
            print(f"Failed to copy {s} to {d}: {e}")

# Define the source and destination directories
src_dir = input("Enter the source directory path: ")
dst_dir = input("Enter the destination directory path: ")
find_text = input("Enter the text to find (e.g., 'src'): ")
replace_text = input("Enter the text to replace with (e.g., 'drc'): ")

# Copy all files and folders from the source directory to the destination directory
rename_and_replace(src_dir, dst_dir, find_text, replace_text)

print("Copy and replace process completed.")
