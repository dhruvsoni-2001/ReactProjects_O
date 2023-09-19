# import shutil
# import os
# import re

# def rename_cs_files(path, old_namespace, new_namespace):
#     for root, dirs, files in os.walk(path):
#         for filename in files:
#             if filename.endswith(".cs"):
#                 file_path = os.path.join(root, filename)
#                 with open(file_path, "r") as file:
#                     file_data = file.read()
#                 # Replace old namespace with new namespace in the file content
#                 file_data = file_data.replace(old_namespace, new_namespace)
#                 with open(file_path, "w") as file:
#                     file.write(file_data)

# def rename_and_replace(src_dir, dst_dir, find, replace):
#     # Create the destination directory if it doesn't exist
#     if not os.path.exists(dst_dir):
#         os.makedirs(dst_dir)

#     for item in os.listdir(src_dir):
#         s = os.path.join(src_dir, item)
#         d = os.path.join(dst_dir, item)

#         try:
#             if os.path.isdir(s):
#                 # Generate a new folder name with find and replace
#                 new_folder_name = item.replace(find, replace)
#                 d = os.path.join(dst_dir, new_folder_name)
#                 shutil.copytree(s, d)
#                 # Recursively replace "find" with "replace" in folder names and file contents
#                 rename_and_replace(s, d, find, replace)
#             else:
#                 shutil.copy2(s, d)
#                 if s.endswith(".cs"):
#                     # Replace "find" with "replace" in C# file content
#                     with open(d, "r") as file:
#                         file_data = file.read()
#                     file_data = re.sub(r'\b' + re.escape(find) + r'\b', replace, file_data)
#                     with open(d, "w") as file:
#                         file.write(file_data)
#         except Exception as e:
#             print(f"Failed to copy {s} to {d}: {e}")

# # Define the source and destination directories
# src_dir = input("Enter the source directory path: ")
# dst_dir = input("Enter the destination directory path: ")
# find_text = input("Enter the text to find (e.g., 'src'): ")
# replace_text = input("Enter the text to replace with (e.g., 'drc'): ")

# # Copy all files and folders from the source directory to the destination directory
# rename_and_replace(src_dir, dst_dir, find_text, replace_text)

# print("Copy and replace process completed.")
# --------------------------------------------------------------------------------------

# import shutil
# import os
# import re

# def rename_and_replace(src_dir, dst_dir, find, replace):
#     # Create the destination directory if it doesn't exist
#     if not os.path.exists(dst_dir):
#         os.makedirs(dst_dir)

#     for item in os.listdir(src_dir):
#         s = os.path.join(src_dir, item)
#         d = os.path.join(dst_dir, item)

#         try:
#             if os.path.isdir(s):
#                 # Generate a new folder name with find and replace
#                 new_folder_name = item.replace(find, replace)
#                 d = os.path.join(dst_dir, new_folder_name)
#                 shutil.copytree(s, d)
#                 # Recursively replace "find" with "replace" in folder names and file contents
#                 rename_and_replace(s, d, find, replace)
#             else:
#                 # Rename files with "find" in their names to "replace"
#                 new_file_name = item.replace(find, replace)
#                 d = os.path.join(dst_dir, new_file_name)
#                 shutil.copy2(s, d)
#                 if s.endswith(".cs"):
#                     # Replace "find" with "replace" in C# file content
#                     with open(d, "r") as file:
#                         file_data = file.read()
#                     file_data = re.sub(r'\b' + re.escape(find) + r'\b', replace, file_data)
#                     with open(d, "w") as file:
#                         file.write(file_data)
#         except Exception as e:
#             print(f"Failed to copy {s} to {d}: {e}")

# # Define the source and destination directories
# src_dir = input("Enter the source directory path: ")
# dst_dir = input("Enter the destination directory path: ")
# find_text = input("Enter the text to find (e.g., 'src'): ")
# replace_text = input("Enter the text to replace with (e.g., 'drc'): ")

# # Copy all files and folders from the source directory to the destination directory
# rename_and_replace(src_dir, dst_dir, find_text, replace_text)

# print("Copy and replace process completed.")


# ---------------------------  folder name change.  ------------------------------------- 

import os
import shutil

def copy_and_rename(source_folder, source_name, target_folder, target_name):
    for root, dirs, files in os.walk(source_folder):
        for dir_name in dirs[:]:
            if source_name in dir_name:
                new_dir_name = dir_name.replace(source_name, target_name)
                source_path = os.path.join(root, dir_name)
                target_path = os.path.join(target_folder, os.path.relpath(source_path, source_folder))
                target_path = os.path.join(target_path, new_dir_name)
                shutil.copytree(source_path, target_path)
                shutil.rmtree(source_path)
                dirs.remove(dir_name)
                dirs.append(new_dir_name)

        for file_name in files:
            if source_name in file_name:
                new_file_name = file_name.replace(source_name, target_name)
                source_path = os.path.join(root, file_name)
                target_path = os.path.join(target_folder, os.path.relpath(source_path, source_folder))
                target_path = os.path.join(target_path, new_file_name)
                shutil.copy2(source_path, target_path)
                os.remove(source_path)

if __name__ == "__main__":
    source_folder = input("Enter source folder path: ")
    source_name = input("Enter source name: ")
    target_folder = input("Enter target folder path: ")
    target_name = input("Enter target name: ")

    if not os.path.exists(target_folder):
        os.makedirs(target_folder)

    copy_and_rename(source_folder, source_name, target_folder, target_name)
    print("Copying and renaming completed.")