#pragma once

#define WIN32_LEAN_AND_MEAN             // Exclude rarely-used stuff from Windows headers
#include <vector>
#include <string>
#include <filesystem>

std::vector<std::string> getFilesList(std::string path);