#include "pch.h"
#include "PocExcel.h"


#include <iostream>

using namespace System;
using namespace Microsoft::Office::Interop::Excel;

#define Excel   Microsoft::Office::Interop::Excel

void PocExcel::ShowExcelSheetName()
{
	Excel::Application^ app = gcnew Excel::ApplicationClass();
	Workbooks^ wrkbk = app->Workbooks;
	wrkbk->Open("D:\\Temp\\TestWorkbook.xlsx", Type::Missing, Type::Missing, Type::Missing, Type::Missing,
		Type::Missing, Type::Missing, Type::Missing, Type::Missing, Type::Missing, Type::Missing,
		Type::Missing, Type::Missing, Type::Missing, Type::Missing);
	std::cout << msclr::interop::marshal_as<std::string>((wrkbk[1]->Name)) << std::endl;
	std::cout << msclr::interop::marshal_as<std::string>((static_cast<Worksheet^>(wrkbk[1]->Worksheets[1])->Name)) << std::endl;
	wrkbk->Close();
	app->Quit();
}

IEnumerable<String^>^ PocExcel::GetColumnFromFirstSheet(String^ workbook)
{
	vector<String^>^ result = gcnew vector<String^>();
	Excel::Application^ app = gcnew Excel::ApplicationClass();
	Workbooks^ wrkbk = app->Workbooks;
	wrkbk->Open(workbook, Type::Missing, Type::Missing, Type::Missing, Type::Missing,
		Type::Missing, Type::Missing, Type::Missing, Type::Missing, Type::Missing, Type::Missing,
		Type::Missing, Type::Missing, Type::Missing, Type::Missing);
	Worksheet^ wrksheet = static_cast<Worksheet^>(wrkbk[1]->Worksheets[1]);
	int lastRow =  wrksheet->Cells->Find("*", System::Reflection::Missing::Value,
		System::Reflection::Missing::Value, System::Reflection::Missing::Value,
		Excel::XlSearchOrder::xlByRows, Excel::XlSearchDirection::xlPrevious,
		false, System::Reflection::Missing::Value, System::Reflection::Missing::Value)->Row; 
	for (int i = 1; i <= lastRow; ++i)
	{
		Range^ r = static_cast<Range^>(wrksheet->Cells[i,1]); 
		result->push_back(static_cast<String^>(r->Text));

	}
	wrkbk->Close();
	app->Quit();
	return  result;
}

IEnumerable<IEnumerable<String^>^>^ PocExcel::GetTableFromFirstSheet(String^ workbook)
{
	vector< IEnumerable<String^>^>^ result = gcnew vector< IEnumerable<String^>^>();;
	Excel::Application^ app = gcnew Excel::ApplicationClass();
	Workbooks^ wrkbk = app->Workbooks;
	wrkbk->Open(workbook, Type::Missing, Type::Missing, Type::Missing, Type::Missing,
		Type::Missing, Type::Missing, Type::Missing, Type::Missing, Type::Missing, Type::Missing,
		Type::Missing, Type::Missing, Type::Missing, Type::Missing);
	Worksheet^ wrksheet = static_cast<Worksheet^>(wrkbk[1]->Worksheets[1]);
	int lastRow = wrksheet->Cells->Find("*", System::Reflection::Missing::Value,
		System::Reflection::Missing::Value, System::Reflection::Missing::Value,
		Excel::XlSearchOrder::xlByRows, Excel::XlSearchDirection::xlPrevious,
		false, System::Reflection::Missing::Value, System::Reflection::Missing::Value)->Row;
	for (int i = 1; i <= lastRow; ++i)
	{
		vector<String^>^ line = gcnew vector<String^>();
		for (int j = 0; j <= 1; ++j)
		{
			Range^ r = static_cast<Range^>(wrksheet->Cells[i, 1 + j]);
			line->push_back(static_cast<String^>(r->Text));
		}
		result->push_back(line);
	}
	wrkbk->Close();
	app->Quit();


	return result;
}
