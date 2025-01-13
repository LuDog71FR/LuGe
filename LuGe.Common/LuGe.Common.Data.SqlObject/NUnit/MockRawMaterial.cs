/*
 * User: Ludovic Germain
 * Date: 23/07/2007
 * Time: 15:03
 */

using System;
using LuGe.Common.Data.SqlObject;

namespace LuGe.Common.Data.SqlObject.Tests
{
	[TableInfo("RawMaterial")]
	public class MockRawMaterial : LISqlObject
	{
		#region Fields
		
		[ColumnInfo("rmIndex", true)] private string _rmIndex;
		[ColumnInfo("rmText")] private string _rmText;
		[ColumnInfo("rmWeight")] private Single _rmWeight;
		
		#endregion
		
		#region Constructors
		
		public MockRawMaterial(LIConnection connection) : base(connection) {}
		
		#endregion
		
		#region Properties
		
		public string RmIndex {
			get { return _rmIndex; }
			set 
			{ 
			    _rmIndex = value; 
			    this.OnPropertyChanged("RmIndex");
			}
		}
		
		public string RmText {
			get { return _rmText; }
			set 
			{ 
			    _rmText = value; 
			    this.OnPropertyChanged("RmText");
			}
		}
		
		public Single RmWeight {
			get { return _rmWeight; }
			set 
			{ 
			    _rmWeight = value; 
			    this.OnPropertyChanged("RmWeight");
			}
		}
		
		#endregion
		
		#region Methods
		
		#endregion
	}
}
