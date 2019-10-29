using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiniteStateMachine
{
	static class Constant
	{
		public const int FSM_RUN = 1;
		public const int FSM_PAUSE = 0;
		public const int FSM_STOP = -1;

		public const int FSM_NO_STS = -1;
		public const int FSM_IDLE = 0x0000;
		public const int FSM_SUSPEN = 0x0001;
		public const int FSM_ERROR = 0x0002;
		public const int FSM_USER_BASE = 0x0010;
		public const int FSM_USER_BASE_END = 0x7FFF;


	}

	public interface CFsmErrorBase
	{
		long nErrorHandle(long nErrCode, IntPtr pErr);

	}

	public interface CFsmCallBackBase
	{
		long nFsmCallBack(int nInput);
	}

	public interface CFsmBase : CFsmErrorBase , CFsmCallBackBase
	{

		long nExecute();                            // FSM 執行的介面
		void vOnInitial();                      // FSM Initial的介面
		long nGetCurrState();                   // 讀取目前狀態介面
		long nGetLastState();                   // 讀取上個狀態介面

		void vCommand(long nCmd, long nTarget, int nLevel, Object pData = null);
		long nGetCommand(ref long pData);
		void vResetCommand();
		long nDoSFC(int nFunIdx);               // SFC命令介面
		Object pvGetData(int nIdx);             // 狀態取出FSM資料的介面

		// Log 介面
		bool bLogEn();
		void vLog(int nSec, string pstrFUNC, long nLine, string pstrMsg);
		void vUpdateLog();
	}

   public abstract class CFsmState : CFsmBase
{
		//===========================//
		//   private member data     //
		//===========================//

		//CRITICAL_SECTION m_hCsExe;
		private CFsmBase m_pcParent;

		//===========================//
		//  public member function   //
		//===========================//

		public CFsmState()
		{

		}
		~CFsmState()
		{

		}

		// Execution Interface
		public abstract long nExecute();                                // return current status.

		// Initial Interface, executed when the state being created
		public void vOnCreate()
		{
		}
		// Initialize the state. Executed when Mahcine runs the vOnInitial() itself.
		public void vOnInitial()
		{
		}

		
		// Get the current state.
		public long nGetCurrState()
		{
			return m_nCurrState;
		}
		// Get the last state.
		public long nGetLastState()
		{
			return m_pcParent.nGetLastState();
		}

	// Command Interface
	void vCommand(long nCmd, Object pData = null)
		{
			vCommand(nCmd, FSM_CMD_ALL_TARGET, FSM_CMD_LVL_MID, pData);
		}
	void vCommand(long nCmd, long nTarget, int nLevel, Object pData)
		{

		}
	virtual long nGetCommand(void** pData = NULL);          // Get Command From FSM.
	virtual void vResetCommand();                           // Reset FSM Command buffer manually.

	// Data Handle Interface
	
	virtual void* pvGetData(int nIdx);                      // Get data object.

	// Call Back Interface
	virtual long nErrorHandle(long nErrCode, void* pErr);   // Error Handle callback function.
	virtual long nFsmCallBack(int nInput);                  // General purpose callback function.

	// Internal Function
	long nStateExecute();                           // 
	CFsmBase* pGetParent();
	void vSetParent(CFsmBase* pcPtr);

	//===========================//
	// protected member function //
	//===========================//
	protected:
	virtual bool bLogEn();                                                                      // Is Log Enabled or not
	virtual void vLog(int nSec, const char* pstrFUNC, long nLine, const char* pstrMsg);         // Log Function
	virtual void vLog(int nSec, const wchar_t* pstrFUNC, long nLine, const wchar_t* pstrMsg);   // Log Function
	virtual void vUpdateLog();                                                                  // Log Function

	//===========================//
	//   protected member data   //
	//===========================//
	protected long m_nCurrState;


}


}
