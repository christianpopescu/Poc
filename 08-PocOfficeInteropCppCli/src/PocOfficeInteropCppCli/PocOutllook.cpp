#include "pch.h"
#include "PocOutllook.h"
#include <msclr\marshal_cppstd.h>

#include <iostream>

using namespace System;
//using namespace Microsoft::Office::Interop::Outlook;

#define Outlook   Microsoft::Office::Interop::Outlook

void PocOutllook::ShowFolderList()
{
	Outlook::Application^ app = gcnew Outlook::ApplicationClass();

	Outlook::Folder^ fldr = static_cast<Outlook::Folder^> (app->Session->DefaultStore->GetRootFolder());

	EnumerateFolder(fldr, 0);

	
}

void PocOutllook::EnumerateAllFolders(Outlook::Folder^ pFolder)
{
	EnumerateFolder(pFolder, 0);
}

void PocOutllook::EnumerateFolder(Outlook::Folder^ pFolder, int depth)
{
	Outlook::Folders^ childrenFolders = pFolder->Folders;
	depth++;
	std::string ident(depth * 2, ' ');
	for (int i=1; i< childrenFolders->Count; i++)
	{
		
		std::cout << ident << msclr::interop::marshal_as<std::string>((childrenFolders[i]->Name)) << std::endl;
		EnumerateFolder(static_cast<Outlook::Folder^>(childrenFolders[i]), depth + 1);
	}
	
}
