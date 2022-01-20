#include "pch.h"
#include "PocMFCDlg_Model.h"

PocMFCDlgModel::PocMFCDlgModel()
	:Output(_T(""))
{
}

void PocMFCDlgModel::ButtonPushed()
{
	Output.Append(_T("Test added Text \r\n Test Test"));
}
