<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="Vessels.aspx.vb" Inherits="CrewSys.Vessels" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            $("#<%= ddlPrincipalCode.ClientID%>").selectpicker();
            $("#<%= ddlFlag.ClientID%>").selectpicker();
            $("#<%= ddlYear.ClientID%>").selectpicker();
            $("#<%= ddlVesselType.ClientID%>").selectpicker();
            $("#<%= ddlDocCode.ClientID%>").selectpicker();
            $("#<%= ddlDocCodeUpdate.ClientID%>").selectpicker();
            $("#<%= ddlCBA.ClientID%>").selectpicker();

            $(".selectpicker").selectpicker();
            $('.multipleSelect').fastselect();
        });

        function RefreshDDL() {
            $("#<%= ddlPrincipalCode.ClientID%>").selectpicker();
            $("#<%= ddlFlag.ClientID%>").selectpicker();
            $("#<%= ddlYear.ClientID%>").selectpicker();
            $("#<%= ddlVesselType.ClientID%>").selectpicker();
            $("#<%= ddlDocCode.ClientID%>").selectpicker();
            $("#<%= ddlDocCodeUpdate.ClientID%>").selectpicker();
            $("#<%= ddlCBA.ClientID%>").selectpicker();
        }
        $(function () {
            RefreshDDL()
        });
        function pageLoad(sender, args) {
            RefreshDDL()

            $('[id*=VesselStatus]').bootstrapToggle({
                on: 'ACTIVE',
                off: 'INACTIVE',
                onstyle: 'primary',
                offstyle: 'warning'
            });
        
        $('[id*=chkArchiveUpdate]').bootstrapToggle({
            on: 'NO',
            off: 'YES',
            onstyle: 'primary',
            offstyle: 'success'
        });
        }

        function openModalDs() {
            $('#CrewDocs').modal('show');
        }

        function openModalD() {
            $('#CrewDoc').modal('show');
        }

        function openModalDu() {
            $('#CrewDocU').modal('show');
        }
    </script>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="page-header card">
        <div class="card-block">
            <h5 class="m-b-10">VESSELS</h5>
            <p class="text-muted m-b-10">Manage Vessels</p>
        </div>
    </div>

    <asp:UpdatePanel ID="upVessels" runat="server">
        <ContentTemplate>

            <div class="card-block">

                <div class="row">
                    <div class="col-md-12 col-lg-4">
                        <div class="card">
                            <div class="card-block text-center">
                                <i class="ti-anchor text-c-blue d-block f-40"></i>
                                <h4 class="m-t-20">All Vessels</h4>
                                <asp:LinkButton ID="lbAll" CssClass="btn btn-primary btn-round" runat="server"></asp:LinkButton>
                            </div>
                        </div>
                    </div>

                    <div class="col-md-12 col-lg-4">
                        <div class="card">
                            <div class="card-block text-center">
                                <i class="fa fa-ship text-c-green d-block f-40"></i>
                                <h4 class="m-t-20">Active Vessels</h4>
                                <asp:LinkButton ID="lbActive" CssClass="btn btn-success btn-round" runat="server"></asp:LinkButton>
                            </div>
                        </div>
                    </div>

                    <div class="col-md-12 col-lg-4">
                        <div class="card">
                            <div class="card-block text-center">
                                <i class="fa fa-ship text-c-yellow d-block f-40"></i>
                                <h4 class="m-t-20">Inactive Vessels</h4>
                                <asp:LinkButton ID="lbInactive" CssClass="btn btn-warning btn-round" runat="server"></asp:LinkButton>
                            </div>
                        </div>
                    </div>

                </div>
            </div>


            <div class="page-body">
                <div class="card">
                    <div class="card-block">


                        <div class="row">
                            <div class="col-sm-4">
                                <asp:Button ID="btnAddNew" runat="server" Text="Add New Vessel" CssClass="btn btn-success pull-left" UseSubmitBehavior="False" />
                            </div>
                            <div class="col-sm-8">
                                <div class="form-group row">
                                    <div class="col-md-12 col-lg-5">
                                        <asp:Label ID="lblddlPrincipal" runat="server" Text="Principal:" Font-Bold="True"></asp:Label>
                                        <asp:DropDownList ID="ddlPrincipal" runat="server" CssClass="form-control selectpicker pull-right" data-live-search="true"></asp:DropDownList>
                                    </div>
                                    <div class="col-md-12 col-lg-5">
                                        <asp:Label ID="lblVessel" runat="server" Text="Vessel:" Font-Bold="True"></asp:Label>
                                        <asp:DropDownList ID="ddlVessel" runat="server" CssClass="form-control selectpicker pull-right" data-live-search="true"></asp:DropDownList>
                                    </div>
                                    <div class="col-md-12 col-lg-2">
                                        <asp:Label ID="lblSearch" runat="server" Text="Search" Font-Bold="True"></asp:Label>
                                        <button id="btnGo1" type="submit" class="input-group-addon search-btn" runat="server">
                                            <i class="ti-search"></i>
                                        </button>
                                    </div>
                                </div>
                            </div>
                        </div>



                        <asp:MultiView ID="MultiView1" runat="server">

                            <asp:View ID="vVessels" runat="server">

                                <div class="table-responsive">

                                    <asp:GridView ID="gvVessel" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" CssClass="table table-striped table-bordered nowrap dataTable no-footer dtr-inline collapsed" PageSize="30" EmptyDataText="There are no data records to display">
                                        <Columns>

                                            <asp:TemplateField HeaderText="Vessel Name" SortExpression="VesselName">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lbVesselName" runat="server" Text='<%# Bind("VesselName") %>' CommandName="View" CommandArgument='<%#Eval("ID")%>' CssClass="text-primary"></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="Description" HeaderText="Principal" SortExpression="Description" />
                                            <asp:BoundField DataField="Country" HeaderText="Flag" SortExpression="Country" />
                                            <asp:BoundField DataField="LookUpDescription" HeaderText="Vessel Type" SortExpression="LookUpDescription" />
                                            <asp:BoundField DataField="GRT" HeaderText="GRT" SortExpression="GRT" />
                                            <asp:BoundField DataField="Imono" HeaderText="IMO No" SortExpression="Imono" />
                                            <asp:BoundField DataField="VesselStatus" HeaderText="Status" SortExpression="VesselStatus" />

                                        </Columns>

                                        <PagerStyle CssClass="GridPager" HorizontalAlign="Center" />
                                        <HeaderStyle ForeColor="Blue" />

                                    </asp:GridView>


                                    <asp:GridView ID="gvVesselP" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" CssClass="table table-striped b-t b-light" PageSize="30" EmptyDataText="There are no data records to display">
                                        <Columns>

                                            <asp:TemplateField HeaderText="Vessel Name" SortExpression="VesselName">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblVesselName" runat="server" Text='<%# Bind("VesselName") %>' CssClass="text-primary"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="Country" HeaderText="Flag" SortExpression="Country" />
                                            <asp:BoundField DataField="LookUpDescription" HeaderText="Vessel Type" SortExpression="LookUpDescription" />
                                            <asp:BoundField DataField="GRT" HeaderText="GRT" SortExpression="GRT" />
                                            <asp:BoundField DataField="Imono" HeaderText="IMO No" SortExpression="Imono" />
                                            <asp:BoundField DataField="VesselStatus" HeaderText="Status" SortExpression="VesselStatus" />

                                        </Columns>

                                        <PagerStyle CssClass="GridPager" HorizontalAlign="Center" />
                                        <HeaderStyle ForeColor="Blue" />

                                    </asp:GridView>

                                </div>

                            </asp:View>




                            <asp:View ID="vUpdateVessels" runat="server">
                                <div class="panel panel-default">
                                    <div class="panel-heading bg-primary">
                                        <asp:Label ID="lblHead" runat="server" Text="Label"></asp:Label>
                                    </div>
                                    <div class="panel-body">

                                        <br />
                                        <div class="form-group row">
                                            <label class="col-sm-2 col-form-label">Principal</label>
                                            <div class="col-sm-10">
                                                <asp:DropDownList ID="ddlPrincipalCode" runat="server" CssClass="form-control selectpicker" data-live-search="true"></asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <label class="col-sm-2 col-form-label">Vessel Code<span class="required">*</span></label>
                                            <div class="col-sm-10">
                                                <asp:TextBox ID="txtVesselCode" runat="server" CssClass="form-control form-control-round" placeholder="Vessel Code" ReadOnly="True"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <label class="col-sm-2 col-form-label">Vessel Name<span class="required">*</span></label>
                                            <div class="col-sm-10">
                                                <asp:TextBox ID="txtVesselName" runat="server" CssClass="form-control form-control-round" placeholder="Vessel Name"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <label class="col-sm-2 col-form-label">Ex Vessel Name</label>
                                            <div class="col-sm-10">
                                                <asp:TextBox ID="txtExVesselName" runat="server" CssClass="form-control form-control-round" placeholder="Ex Vessel Name"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <label class="col-sm-2 col-form-label">Call Sign<span class="required">*</span></label>
                                            <div class="col-sm-10">
                                                <asp:TextBox ID="txtCallSign" runat="server" CssClass="form-control form-control-round" placeholder="Call Sign"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <label class="col-sm-2 col-form-label">IMO<span class="required">*</span></label>
                                            <div class="col-sm-10">
                                                <asp:TextBox ID="txtIMONo" runat="server"
                                                    onkeydown="if(event.keyCode<48 || event.keyCode>57)event.returnValue=false;"
                                                    CssClass="form-control form-control-round" placeholder="IMO"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <label class="col-sm-2 col-form-label">Official Number<span class="required">*</span></label>
                                            <div class="col-sm-10">
                                                <asp:TextBox ID="txtOfficialNo" runat="server"
                                                    onkeydown="if(event.keyCode<48 || event.keyCode>57)event.returnValue=false;"
                                                    CssClass="form-control form-control-round" placeholder="Official Number"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <label class="col-sm-2 col-form-label">Flag</label>
                                            <div class="col-sm-10">
                                                <asp:DropDownList ID="ddlFlag" runat="server" CssClass="form-control selectpicker" data-live-search="true"></asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <label class="col-sm-2 col-form-label">Vessel Type</label>
                                            <div class="col-sm-10">
                                                <asp:DropDownList ID="ddlVesselType" runat="server" CssClass="form-control selectpicker" data-live-search="true"></asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <label class="col-sm-2 col-form-label">Vessel Status<span class="required">*</span></label>
                                            <div class="col-sm-10">
                                                <input id="VesselStatus" type="checkbox" runat="server" />
                                                <asp:HiddenField ID="hdnVesselStat" runat="server" />
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <label class="col-sm-2 col-form-label">GRT<span class="required">*</span></label>
                                            <div class="col-sm-10">
                                                <asp:TextBox ID="txtGRT" runat="server"
                                                    onkeydown="if(event.keyCode<48 || event.keyCode>57)event.returnValue=false;"
                                                    CssClass="form-control form-control-round" placeholder="GRT"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <label class="col-sm-2 col-form-label">Net Tons<span class="required">*</span></label>
                                            <div class="col-sm-10">
                                                <asp:TextBox ID="txtNetTons" runat="server"
                                                    onkeydown="if(event.keyCode<48 || event.keyCode>57)event.returnValue=false;"
                                                    CssClass="form-control form-control-round" placeholder="Net Tons"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <label class="col-sm-2 col-form-label">Engine Type<span class="required">*</span></label>
                                            <div class="col-sm-10">
                                                <asp:TextBox ID="txtEngineType" runat="server" CssClass="form-control form-control-round" placeholder="Engine Type"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <label class="col-sm-2 col-form-label">Year Built<span class="required">*</span></label>
                                            <div class="col-sm-10">
                                                <asp:DropDownList ID="ddlYear" runat="server" CssClass="form-control selectpicker" data-live-search="true"></asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <label class="col-sm-2 col-form-label">Class Society<span class="required">*</span></label>
                                            <div class="col-sm-10">
                                                <asp:TextBox ID="txtClassification" runat="server" CssClass="form-control form-control-round" placeholder="Class Society"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <label class="col-sm-2 col-form-label">CBA<span class="required">*</span></label>
                                            <div class="col-sm-10">
                                                <asp:DropDownList ID="ddlCBA" runat="server" CssClass="form-control selectpicker" data-live-search="true"></asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <label class="col-sm-2 col-form-label">Builder<span class="required">*</span></label>
                                            <div class="col-sm-10">
                                                <asp:TextBox ID="txtBuilder" runat="server" CssClass="form-control form-control-round" placeholder="Builder"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <label class="col-sm-2 col-form-label">Engine Maker<span class="required">*</span></label>
                                            <div class="col-sm-10">
                                                <asp:TextBox ID="txtEngineMaker" runat="server" CssClass="form-control form-control-round" placeholder="Engine Maker"></asp:TextBox>
                                            </div>
                                        </div>

                                        <div class="actionbar">
                                            <asp:LinkButton ID="lbBack" runat="server" CssClass="btn btn-success pull-left">Back to Search</asp:LinkButton>
                                            <asp:Button ID="btnAddUpdateVessel" runat="server" Text="Update Vessel" CssClass="btn btn-success pull-right" />
                                        </div>
                                    </div>
                                </div>

                                
                                <div class="panel panel-default">
                                    <div class="panel-body">
                                        <button type="button" name="btnAddDoc" id="btnAddDoc" class="btn btn-success pull-right" data-toggle="modal" data-target="#CrewDoc" runat="server">Add Documents</button>
                                        <br />
                                <div class="table-responsive">
                                    <%--     <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                                        <ContentTemplate>--%>

                                    <asp:GridView ID="gvDocs" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" CssClass="table table-striped table-bordered nowrap dataTable no-footer dtr-inline collapsed" PageSize="30" EmptyDataText="There are no data records to display">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Document Title" SortExpression="DocTitle">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lbDoc2" runat="server" Text='<%#Eval("DocTitle")%>' CommandName="ViewDocs2" CommandArgument='<%#Eval("ID")%>'></asp:LinkButton>
                                                    <asp:HiddenField ID="hdnDocTitle" runat="server" Value='<%#Bind("ExpiryDate")%>'></asp:HiddenField>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="DocNo" HeaderText="Document Number" />
                                            <asp:BoundField DataField="IssuedDate" HeaderText="Issued Date" DataFormatString="{0:MM/dd/yyyy }" HtmlEncode="false" ItemStyle-HorizontalAlign="Center" />
                                            <asp:BoundField DataField="ExpiryDate" HeaderText="Expiry Date" DataFormatString="{0:MM/dd/yyyy }" HtmlEncode="false" ItemStyle-HorizontalAlign="Center" />
                                            <asp:BoundField DataField="Remarks" HeaderText="Remarks" />
                                        </Columns>

                                        <PagerStyle CssClass="GridPager" HorizontalAlign="Center" />
                                        <HeaderStyle ForeColor="Blue" />

                                    </asp:GridView>

                                    <%--  </ContentTemplate>
                                                        <Triggers>
                                                            <asp:PostBackTrigger ControlID="btnCrewDocuUpdate" />
                                                        </Triggers>
                                                    </asp:UpdatePanel>--%>
                                </div>
                                          </div>
                                      </div>
                            </asp:View>



                            <asp:View ID="vAddNewKeywords" runat="server">
                                <!-- Add Keywords -->
                                <asp:HiddenField ID="hdnMode" runat="server" />
                                <asp:HiddenField ID="hdnID" runat="server" />
                                <asp:HiddenField ID="hdnView" runat="server" />
                            </asp:View>



                            <asp:View ID="vActionNotification" runat="server">
                                <h4>
                                    <asp:Label ID="lblMessage" runat="server" Text=" Record Successfully Saved"></asp:Label></h4>
                                <div class="actionBar">
                                    <asp:Button ID="btnBack2" runat="server" Text="Continue" CssClass="btn btn-success pull-right" />
                                </div>
                            </asp:View>

                        </asp:MultiView>

                    </div>
                </div>
            </div>

        </ContentTemplate>
    </asp:UpdatePanel>


    
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            


            <!-- Modal -->
            <div class="modal fade" id="CrewDocU" tabindex="-1" role="dialog">
                <div class="modal-dialog modal-lg" role="document">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h4 class="modal-title">Add Crew Document</h4>
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span>
                            </button>
                        </div>
                            <div class="form-group row">
                                <label class="col-sm-2 col-form-label">Document Title<span class="required">*</span></label>
                                <div class="col-sm-10">
                                    <asp:DropDownList ID="ddlDocCodeUpdate" runat="server" CssClass="form-control selectpicker" placeholder="Select Document" data-live-search="true"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group row">
                                <label class="col-sm-2 col-form-label">Upload Document<span class="required">*</span></label>
                                <div class="col-sm-10">
                                    <asp:FileUpload ID="fuDocUpdate" runat="server"></asp:FileUpload>
                                    <asp:RegularExpressionValidator ControlToValidate="fuPath" ValidationExpression="^.*\.(pdf|PDF|jpg|jpeg|JPG|JPEG|png|PNG)$" runat="server" ErrorMessage="Upload ONLY pdf, jpg, png formats!" CssClass="text-danger" />
                                </div>
                                <asp:Label ID="lblWarning3" runat="server" Text=""></asp:Label>
                            </div>
                            <div class="form-group row">
                                <label class="col-sm-2 col-form-label">Issued Date<span class="required">*</span></label>
                                <div class="col-sm-10">
                                    <asp:TextBox ID="txtIDateUpdate" runat="server" CssClass="form-control form-control-round" placeholder="MM/dd/yyyy"></asp:TextBox>
                                    <ajax:CalendarExtender ID="ceIDateUpdate" PopupButtonID="imgPopup" runat="server" TargetControlID="txtIDateUpdate" Format="MM/dd/yyyy"></ajax:CalendarExtender>
                                    <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender5" runat="server" Enabled="True" Mask="99/99/9999" MaskType="Date"
                                        InputDirection="LefttoRight" TargetControlID="txtIDateUpdate" />
                                </div>
                            </div>
                            <div class="form-group row">
                                <label class="col-sm-2 col-form-label">Expiry Date<span class="required">*</span></label>
                                <div class="col-sm-10">
                                    <asp:TextBox ID="txtExDateUpdate" runat="server" CssClass="form-control form-control-round" placeholder="MM/dd/yyyy"></asp:TextBox>
                                    <ajax:CalendarExtender ID="ceExDateUpdate" PopupButtonID="imgPopup" runat="server" TargetControlID="txtExDateUpdate" Format="MM/dd/yyyy"></ajax:CalendarExtender>
                                    <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender3" runat="server" Enabled="True" Mask="99/99/9999" MaskType="Date"
                                        InputDirection="LefttoRight" TargetControlID="txtExDateUpdate" />
                                    <asp:CheckBox ID="chkNoExpiryU" runat="server" Text="No Expiration" />
                                </div>
                            </div>
                            <div class="form-group row">
                                <label class="col-sm-2 col-form-label">Archive</label>
                                <div class="col-sm-10">
                                    <input id="chkArchiveUpdate" type="checkbox" runat="server" />
                                    <asp:HiddenField ID="hdnArchiveUpdate" runat="server" />
                                </div>
                            </div>
                            <div class="form-group row">
                                <label class="col-sm-2 col-form-label">Remarks</label>
                                <div class="col-sm-10">
                                    <asp:TextBox ID="txtRemarksUpdate" runat="server" CssClass="form-control form-control-round" placeholder="Remarks"></asp:TextBox>
                                </div>
                            </div>

                        </div>

                        <div class="modal-footer">
                            <button type="button" class="btn btn-default waves-effect " data-dismiss="modal">Close</button>
                            <asp:Button ID="btnCrewDocuUpdate" runat="server" Text="Update Crew Document" CssClass="btn btn-success pull-right" UseSubmitBehavior="False" />

                        </div>
                    </div>
                </div>
            </div>
            <!--End of Modal-->

            


            <!-- Modal -->
            <div class="modal fade" id="CrewDocs" tabindex="-1" role="dialog">
                <div class="modal-dialog modal-lg" role="document">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h4 class="modal-title">
                                <asp:Label ID="lblDocTitle" runat="server" Text=""></asp:Label></h4>
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span>
                            </button>
                        </div>
                        <div class="modal-body">

                            <iframe id="ifPDF" runat="server" frameborder="0"
                                style="height: 80vh; width: 100%;"></iframe>

                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-default waves-effect " data-dismiss="modal">Close</button>
                            <asp:Button ID="btnUpdateCrewDoc" runat="server" Text="Update" CssClass="btn btn-success pull-right" UseSubmitBehavior="false" />
                        </div>
                    </div>
                </div>
            </div>
            <!--End of Modal-->

            
            <asp:HiddenField ID="hdnDocPath" runat="server"></asp:HiddenField>
            <asp:HiddenField ID="hdnDocID" runat="server"></asp:HiddenField>

        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnCrewDocuUpdate" />
        </Triggers>
    </asp:UpdatePanel>
    


    <!-- Modal -->
    <div class="modal fade" id="CrewDoc" tabindex="-1" role="dialog">
        <div class="modal-dialog modal-lg" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title">Add Document</h4>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <div class="form-group row">
                        <label class="col-sm-2 col-form-label">Document Title<span class="required">*</span></label>
                        <div class="col-sm-10">
                            <asp:DropDownList ID="ddlDocCode" runat="server" CssClass="form-control selectpicker" placeholder="Select Document" data-live-search="true"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group row">
                        <label class="col-sm-2 col-form-label">Upload Document<span class="required">*</span></label>
                        <div class="col-sm-10">
                            <asp:FileUpload ID="fuPath" runat="server"></asp:FileUpload>
                            <asp:RegularExpressionValidator ControlToValidate="fuPath" ValidationExpression="^.*\.(pdf|PDF|jpg|jpeg|JPG|JPEG|png|PNG)$" runat="server" ErrorMessage="Upload ONLY pdf, jpg, png formats!" CssClass="text-danger" />
                        </div>
                        <asp:Label ID="lblWarning2" runat="server" Text=""></asp:Label>
                    </div>
                    <div class="form-group row">
                        <label class="col-sm-2 col-form-label">Issued Date<span class="required">*</span></label>
                        <div class="col-sm-10">
                            <asp:TextBox ID="txtIDate" runat="server" CssClass="form-control form-control-round" placeholder="MM/dd/yyyy"></asp:TextBox>
                            <ajax:CalendarExtender ID="ceIDate" PopupButtonID="imgPopup" runat="server" TargetControlID="txtIDate" Format="MM/dd/yyyy"></ajax:CalendarExtender>
                            <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender14" runat="server" Enabled="True" Mask="99/99/9999" MaskType="Date"
                                InputDirection="LefttoRight" TargetControlID="txtIDate" />
                        </div>
                    </div>
                    <div class="form-group row">
                        <label class="col-sm-2 col-form-label">Expiry Date<span class="required">*</span></label>
                        <div class="col-sm-10">
                            <asp:TextBox ID="txtExdate" runat="server" CssClass="form-control form-control-round" placeholder="MM/dd/yyyy"></asp:TextBox>
                            <ajax:CalendarExtender ID="ceExdate" PopupButtonID="imgPopup" runat="server" TargetControlID="txtExdate" Format="MM/dd/yyyy"></ajax:CalendarExtender>
                            <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender2" runat="server" Enabled="True" Mask="99/99/9999" MaskType="Date"
                                InputDirection="LefttoRight" TargetControlID="txtExdate" />
                            <asp:CheckBox ID="chkNoExpiry" runat="server" Text="No Expiration" />
                        </div>
                    </div>
                    <div class="form-group row">
                        <label class="col-sm-2 col-form-label">Remarks</label>
                        <div class="col-sm-10">
                            <asp:TextBox ID="txtRemarks" runat="server" CssClass="form-control form-control-round" placeholder="Remarks"></asp:TextBox>
                        </div>
                    </div>
                    <asp:HiddenField ID="hdnPath" runat="server" />
                </div>

                <div class="modal-footer">
                    <button type="button" class="btn btn-default waves-effect " data-dismiss="modal">Close</button>
                    <asp:Button ID="lbSaveDoc" runat="server" Text="Save Document" CssClass="btn btn-success waves-effect waves-light pull-right" UseSubmitBehavior="false" />
                </div>
            </div>
        </div>
    </div>
    <!--End of Modal-->

</asp:Content>
