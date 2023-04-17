import win32com.client as win32

def RecursivePrint(folder, level):
    string_val = "    " * level
    print(string_val + folder.Name)
    for current_folder in folder.Folders:
        RecursivePrint(current_folder, (level+1))


outlook = win32.Dispatch("Outlook.Application")
mapi = outlook.GetNamespace("MAPI")



your_folder = mapi.Folders['christian.popescu@outlook.com'] #.Folders['Inbox']
print(your_folder.Folders.Count)
for current_folder in your_folder.Folders:
    print(current_folder.Name)

RecursivePrint(your_folder, 0)
