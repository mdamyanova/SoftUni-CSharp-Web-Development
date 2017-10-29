import os

search_path = ".\\.\\05.Packages, standard formats, os & sys, time"
search_file = "text.txt"

if os.path.isfile(search_file):
    print("File is found: ",
          os.path.join(search_path, search_file))
else:
    print("File not found")
