#include <windows.h>
#include <iostream>

// Callback function for resource enumeration
BOOL CALLBACK EnumTypesCallback(HMODULE hModule, LPCTSTR lpType, LONG_PTR lParam) {
    std::wcout << L"Resource Type: " << lpType << std::endl;

    // Enumerate resource names of the given type
    EnumResourceNames(hModule, lpType, [](HMODULE hMod, LPCTSTR lpType, LPCTSTR lpName, LONG_PTR lParam) -> BOOL {
        std::wcout << L"  Resource Name: " << lpName << std::endl;
        return TRUE;
        }, lParam);

    return TRUE;
}

int main() {
    HMODULE hModule = LoadLibrary(L"yourdllfile.dll"); // Replace with your DLL file path

    if (hModule) {
        std::cout << "Enumerating resources..." << std::endl;
        EnumResourceTypes(hModule, EnumTypesCallback, 0);
        FreeLibrary(hModule);
    }
    else {
        std::cerr << "Failed to load the DLL." << std::endl;
    }

    return 0;
}
