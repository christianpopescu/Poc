// StaticLibListFiles.cpp : Defines the functions for the static library.
//

#include "pch.h"
#include "StaticLibListfiles.h"

using namespace std;
// TODO: This is an example of a library function
vector<string> getFilesList (string path)
{
	const std::filesystem::path inputPath {path};

	vector<string> result;

	for (auto& dir_entry : std::filesystem::directory_iterator{ inputPath })
	{
		if (dir_entry.is_regular_file())
			result.push_back(dir_entry.path().filename().string());
	}

	return result;
}
