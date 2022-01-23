#include "MainFormModel.h"

MainFormModel::MainFormModel()
{
    text = gcnew System::String("");
}

void MainFormModel::DoAction()
{
    this->text = this->text->Concat(this->text , "Test ");
    NotifyPropertyChanged("text");
}

void MainFormModel::NotifyPropertyChanged(System::String^ propertyName)
{
    System::ComponentModel::PropertyChangedEventArgs^ args =
         gcnew System::ComponentModel::PropertyChangedEventArgs(propertyName);
    PropertyChanged(this, args);
}
