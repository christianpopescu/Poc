#include "pch.h"

using namespace winrt;
using namespace Windows::Foundation;
using namespace Windows::Devices::Input;

int main()
{
    init_apartment();
    Uri uri(L"http://aka.ms/cppwinrt");
    printf("Hello, %ls!\n", uri.AbsoluteUri().c_str());
    KeyboardCapabilities kc = KeyboardCapabilities();
    printf("Keybord present: %s \n", kc.KeyboardPresent() != 0 ? "Yes": "No");
    
}
