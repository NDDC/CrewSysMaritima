<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="Principals.aspx.vb" Inherits="CrewSys.Principals" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript">

        $(document).ready(function () {
            $("#<%= ddlDocCode.ClientID%>").selectpicker();
            $("#<%= ddlDocCodeUpdate.ClientID%>").selectpicker();
          
             $(".selectpicker").selectpicker();
         });

         function RefreshDDL() {
             $("#<%= ddlDocCode.ClientID%>").selectpicker();
            $("#<%= ddlDocCodeUpdate.ClientID%>").selectpicker();
                    
        }
        $(function () {
            RefreshDDL()
        });
        function pageLoad(sender, args) {
            RefreshDDL()

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
            <h5 class="m-b-10">PRINCIPALS</h5>
            <p class="text-muted m-b-10">Manage Principals</p>
        </div>
    </div>



    <div class="page-body">
        <div class="card">
            <div class="card-block">


                <asp:UpdatePanel ID="upPrin" runat="server">
                    <ContentTemplate>


                        <div class="row">
                            <div class="col-sm-6">
                                <asp:Button ID="btnAddNew" runat="server" Text="Add New Principal" CssClass="btn btn-success pull-left" UseSubmitBehavior="False" />
                            </div>
                            <div class="col-sm-6">
                                <div class="form-group row">
                                    <div class="input-group">
                                        <asp:TextBox ID="txtSearch" runat="server" CssClass="form-control form-control-round" placeholder="Search for Principal Name"></asp:TextBox>
                                        <span class="input-group-btn">
                                            <button id="btnGo1" type="submit" class="input-group-addon search-btn" runat="server">
                                                <i class="ti-search"></i>
                                            </button>
                                        </span>
                                    </div>
                                </div>
                            </div>
                        </div>



                        <asp:MultiView ID="MultiView1" runat="server">

                            <asp:View ID="vViewKewords" runat="server">

                                <div class="table-responsive">

                                    <asp:GridView ID="gvPrincipal" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" CssClass="table table-striped table-bordered nowrap dataTable no-footer dtr-inline collapsed" PageSize="30" EmptyDataText="There are no data records to display">
                                        <Columns>
                                            <asp:BoundField DataField="PrincipalCode" HeaderText="Principal Code" SortExpression="PrincipalCode" />
                                            <asp:TemplateField HeaderText="Principal Name" SortExpression="PrincipalName">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lbPrincipalName" runat="server" Text='<%# Bind("PrincipalName") %>' CommandName="View" CommandArgument='<%#Eval("ID")%>' CssClass="text-primary"></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
                                            <asp:BoundField DataField="ContactDetails" HeaderText="Contact Person" SortExpression="ContactDetails" />
                                            <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
                                            <asp:BoundField DataField="Address" HeaderText="Address" SortExpression="Address" />

                                        </Columns>

                                        <PagerStyle CssClass="GridPager" HorizontalAlign="Center" />
                                        <HeaderStyle ForeColor="Blue" />

                                    </asp:GridView>

                                </div>

                            </asp:View>



                            <asp:View ID="vUpdateKeywords" runat="server">
                                <div class="panel panel-default">
                                    <header class="panel-heading bg-primary">
                                        <asp:Label ID="lblHead" runat="server" Text="Label"></asp:Label>
                                    </header>
                                    <div class="panel-body">

                                        <br />
                                        <div class="form-group row">
                                            <label class="col-sm-2 col-form-label">Principal Code</label>
                                            <div class="col-sm-10">
                                                <asp:TextBox ID="txtPrincipalCode" runat="server" CssClass="form-control form-control-round" placeholder="Principal Code" ReadOnly="True"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <label class="col-sm-2 col-form-label">Principal Name</label>
                                            <div class="col-sm-10">
                                                <asp:TextBox ID="txtPrincipalName" runat="server" CssClass="form-control form-control-round" placeholder="Principal Name"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <label class="col-sm-2 col-form-label">Description</label>
                                            <div class="col-sm-10">
                                                <asp:TextBox ID="txtDescription" runat="server" CssClass="form-control form-control-round" placeholder="Description"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <label class="col-sm-2 col-form-label">Contact Person</label>
                                            <div class="col-sm-10">
                                                <asp:TextBox ID="txtContactDetails" runat="server" CssClass="form-control form-control-round" placeholder="Contact Person"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <label class="col-sm-2 col-form-label">Email Address</label>
                                            <div class="col-sm-10">
                                                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control form-control-round" placeholder="Email Address"></asp:TextBox>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmail" ErrorMessage="Invalid Email Address!"
                                                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" CssClass="text-danger"></asp:RegularExpressionValidator>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <label class="col-sm-2 col-form-label">Address</label>
                                            <div class="col-sm-10">
                                                <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control form-control-round" placeholder="Address"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <label class="col-sm-2 col-form-label">Contact Number</label>
                                            <div class="col-sm-10">
                                                <asp:TextBox ID="txtContactNo" runat="server" CssClass="form-control form-control-round" placeholder="Contact Number"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <label class="col-sm-2 col-form-label">First Date of Business</label>
                                            <div class="col-sm-10">
                                                <asp:TextBox ID="txtStart" runat="server" CssClass="form-control form-control-round" placeholder="MM/dd/yyyy"></asp:TextBox>
                                                <ajax:CalendarExtender ID="ceStart" PopupButtonID="imgPopup" runat="server" TargetControlID="txtStart" Format="MM/dd/yyyy"></ajax:CalendarExtender>
                                                <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender6" runat="server" Enabled="True" Mask="99/99/9999" MaskType="Date"
                                                    InputDirection="LefttoRight" TargetControlID="txtStart" />
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <label class="col-sm-2 col-form-label">POEA Accreditation Validity Expiration</label>
                                            <div class="col-sm-10">
                                                <asp:TextBox ID="txtExpiry" runat="server" CssClass="form-control form-control-round" placeholder="MM/dd/yyyy"></asp:TextBox>
                                                <ajax:CalendarExtender ID="ceExpiry" PopupButtonID="imgPopup" runat="server" TargetControlID="txtExpiry" Format="MM/dd/yyyy"></ajax:CalendarExtender>
                                                <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender1" runat="server" Enabled="True" Mask="99/99/9999" MaskType="Date"
                                                    InputDirection="LefttoRight" TargetControlID="txtExpiry" />
                                            </div>
                                        </div>

                                        <div class="actionbar">
                                            <asp:LinkButton ID="lbBack" runat="server" CssClass="btn btn-success pull-left">Back to Search</asp:LinkButton>
                                            <asp:Button ID="btnAddUpdatePrincipals" runat="server" Text="Update Principal Info" CssClass="btn btn-success pull-right" />
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


                    </ContentTemplate>
                </asp:UpdatePanel>


            </div>
        </div>
    </div>

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
                                    <asp:DropDownList ID="ddlDocCodeUpdate" runat="server" required="required" CssClass="form-control selectpicker" placeholder="Select Document" data-live-search="true"></asp:DropDownList>
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
                                    <asp:TextBox ID="txtIDateUpdate" runat="server" required="required" CssClass="form-control form-control-round" placeholder="MM/dd/yyyy"></asp:TextBox>
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
                            <asp:DropDownList ID="ddlDocCode" runat="server" required="required" CssClass="form-control selectpicker" placeholder="Select Document" data-live-search="true"></asp:DropDownList>
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
                            <asp:TextBox ID="txtIDate" runat="server" required="required" CssClass="form-control form-control-round" placeholder="MM/dd/yyyy"></asp:TextBox>
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
