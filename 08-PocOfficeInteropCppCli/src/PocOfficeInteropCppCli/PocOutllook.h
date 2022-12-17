#pragma once
using namespace Microsoft::Office::Interop::Outlook;

#define Outlook   Microsoft::Office::Interop::Outlook

ref class PocOutllook
{
public:
	static void ShowFolderList();

	static void EnumerateAllFolders(Outlook::Folder^ pFolder);

	static void EnumerateFolder(Outlook::Folder^ pFolder, int depth);
};

