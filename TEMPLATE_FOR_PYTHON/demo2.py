import shutil
import os
import re

def rename_cs_files(path, old_text, new_text):
    for root, dirs, files in os.walk(path):
        for filename in files:
            if filename.endswith(".cs"):
                file_path = os.path.join(root, filename)
                with open(file_path, "r") as file:
                    file_data = file.read()
                # Replace old text with new text in the file content
                file_data = file_data.replace(old_text, new_text)
                with open(file_path, "w") as file:
                    file.write(file_data)

def rename_subfolders(src_dir, dst_dir, old_text, new_text):
    for item in os.listdir(src_dir):
        s = os.path.join(src_dir, item)
        d = os.path.join(dst_dir, item)

        try:
            if os.path.isdir(s):
                folder_name = item.replace(old_text, new_text)
                d = os.path.join(dst_dir, folder_name)
                shutil.copytree(s, d)
                # Recursively rename C# files and update their content
                rename_cs_files(d, old_text, new_text)
                # Update subfolder names as well
                rename_subfolders(d, d, old_text, new_text)
            else:
                shutil.copy2(s, d)
        except Exception as e:
            print(f"Failed to copy {s} to {d}: {e}")

 
# Define the source and destination directories
src_dir = input("Enter the source directory path: ")
dst_dir = input("Enter the destination directory path: ")
old_text = input("Enter the text to be replaced: ")
new_text = input("Enter the replacement text: ")

# Create the destination directory if it doesn't exist
if not os.path.exists(dst_dir):
    os.makedirs(dst_dir)

# Copy all files and folders from the source directory to the destination directory
rename_subfolders(src_dir, dst_dir, old_text, new_text)

# Display the list of copied folders
copied_folders = os.listdir(dst_dir)
print("Copied folders:")
for folder in copied_folders:
    print(folder)

print("Copy and text replacement process completed.")