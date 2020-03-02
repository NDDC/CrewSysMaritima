Public Class WebForm1
    Inherits System.Web.UI.Page
    Dim htParameters As New Hashtable
    Dim dt As New DataTable
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load



        htParameters.Add("Mode", 1)
        htParameters.Add("RankCode", DBNull.Value)
        htParameters.Add("CrewStatus", DBNull.Value)
        htParameters.Add("LastName", DBNull.Value)
        htParameters.Add("FirstName", DBNull.Value)
        htParameters.Add("VesselCode", DBNull.Value)
        htParameters.Add("Avail", DBNull.Value)

        dt = MainClass.Library.Adapter.GetRecordSet(htParameters, "CrewInfoSel3")
    End Sub

End Class