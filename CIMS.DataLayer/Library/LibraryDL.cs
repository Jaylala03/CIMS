using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CIMS.BaseLayer;

namespace CIMS.DataLayer
{
   public class LibraryDL
    {
        DataTable dtContainer;
        DataSet dsContainer;

        #region Method Library_AddEdit
        public DataTable Library_AddEdit(LibraryBase library)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@LibraryID", library.LibraryID),
                                           new MyParameter("@LibraryName", library.LibraryName ),
                                           new MyParameter("@FilePath", library.FilePath),
                                           new MyParameter("@FileExistence", library.FileExistence),
                                           new MyParameter("@FileTypeId", library.FileTypeId),
                                          
                                        };
                Common.Set_Procedures("Librarys_AddEdit");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtContainer;
        }
        #endregion

        #region Method Library_Delete
        public DataTable Library_Delete(LibraryBase library)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@LibraryID", library.LibraryID)
                                        };
                Common.Set_Procedures("Librarys_Delete");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtContainer;
        }
        #endregion

        #region Method Visitor_Load
        public DataTable Library_Load(LibraryBase library)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={

                                           new MyParameter("@LibraryID", library.LibraryID)
                                        };
                Common.Set_Procedures("Librarys_Load");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtContainer;
        }
        #endregion

       

    }
}