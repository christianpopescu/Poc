#include "MainFormModel.h"

MainFormModel::MainFormModel()
{
    text = gcnew System::String("");
}

void MainFormModel::DoAction()
{
    this->text = this->text->Concat(this->text , "Test ");
}
