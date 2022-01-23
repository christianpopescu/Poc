#pragma once

ref class MainFormModel : System::ComponentModel::INotifyPropertyChanged
{
public:
	
	property System::String^ text;
	MainFormModel();
	void DoAction();
	virtual event  System::ComponentModel::PropertyChangedEventHandler^ PropertyChanged;
private:
	void NotifyPropertyChanged(System::String^ propertyName);

};

