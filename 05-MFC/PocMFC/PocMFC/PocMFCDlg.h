
// PocMFCDlg.h : header file
//

#pragma once
#include "PocMFCDlg_Model.h"

// CPocMFCDlg dialog
class CPocMFCDlg : public CDialogEx
{
// Construction
public:
	CPocMFCDlg(CWnd* pParent = nullptr);	// standard constructor

// Dialog Data
#ifdef AFX_DESIGN_TIME
	enum { IDD = IDD_POCMFC_DIALOG };
#endif

	protected:
	virtual void DoDataExchange(CDataExchange* pDX);	// DDX/DDV support


// Implementation
protected:
	HICON m_hIcon;

	// Generated message map functions
	virtual BOOL OnInitDialog();
	afx_msg void OnSysCommand(UINT nID, LPARAM lParam);
	afx_msg void OnPaint();
	afx_msg HCURSOR OnQueryDragIcon();
	DECLARE_MESSAGE_MAP()
public:
	afx_msg void OnBnClickedBGetsometext();
	afx_msg void OnEnChangeEdit1();
	CEdit OutputText;
	//CString OutputString;
	PocMFCDlgModel Model;
};
