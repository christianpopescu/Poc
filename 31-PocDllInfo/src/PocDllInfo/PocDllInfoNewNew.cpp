#include <windows.h>
#include <iostream>

// Callback function for resource enumeration
BOOL CALLBACK EnumTypesCallback(HMODULE hModule, LPCWSTR lpType, LONG_PTR lParam) {
    std::wcout << L"Resource Type: " << lpType << std::endl;

    // Enumerate resource names of the given type
    EnumResourceNamesW(hModule, lpType, [](HMODULE hMod, LPCWSTR lpType, LPCWSTR lpName, LONG_PTR lParam) -> BOOL {
        std::wcout << L"  Resource Name: " << lpName << std::endl;
        return TRUE;
    }, lParam);

    return TRUE;
}

int main() {
    HMODULE hModule = LoadLibrary(L"yourdllfile.dll"); // Replace with your DLL file path

    if (hModule) {
        std::cout << "Enumerating resources..." << std::endl;
        EnumResourceTypesW(hModule, EnumTypesCallback, 0);
        FreeLibrary(hModule);
    }
    else {
        std::cerr << "Failed to load the DLL." << std::endl;
    }

    return 0;
}
