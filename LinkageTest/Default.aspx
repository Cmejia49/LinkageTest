<%@ Page Title="Exercise 1 - Amount to Words" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.vb" Inherits="LinkageTest._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main>
        <div class="row">
            <div class="col-md-8">
                <h1>Exercise 1 – Amount to Words Converter</h1>
                <p class="lead">
                    Enter a numeric amount (up to 999,999.99 pesos) and convert it into its English words representation.
                </p>

                <div class="form-horizontal">
                    <div class="form-group">
                        <label for="txtAmount" class="control-label col-md-2">Amount:</label>
                        <div class="col-md-4">
                            <asp:TextBox ID="txtAmount" runat="server" CssClass="form-control" />
                            <asp:RequiredFieldValidator ID="rfvAmount"
                                runat="server"
                                ControlToValidate="txtAmount"
                                CssClass="text-danger"
                                ErrorMessage="Amount is required."
                                Display="Dynamic" />
                            <asp:RegularExpressionValidator ID="revAmount"
                                runat="server"
                                ControlToValidate="txtAmount"
                                CssClass="text-danger"
                                ErrorMessage="Enter a valid positive amount (up to two decimals)."
                                ValidationExpression="^\d+(\.\d{1,2})?$"
                                Display="Dynamic" />
                        </div>
                    </div>

                    <div class="form-group">
                        <div class="col-md-offset-2 col-md-4 mt-3">
                            <asp:Button ID="btnConvert"
                                runat="server"
                                Text="Submit"
                                CssClass="btn btn-primary"
                                OnClick="btnConvert_Click" />
                        </div>
                    </div>

                    <div class="form-group">
                        <div class="col-md-offset-2 col-md-8">
                            <asp:ValidationSummary ID="ValidationSummary1"
                                runat="server"
                                CssClass="text-danger"
                                DisplayMode="BulletList"
                                ShowMessageBox="False"
                                ShowSummary="True" />
                        </div>
                    </div>

                    <div class="form-group">
                        <label class="control-label col-md-2">Result:</label>
                        <div class="col-md-8">
                            <div class="well">
                                <asp:Label ID="lblResult" runat="server" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="col-md-4">
                <h3>Details</h3>
                <p>
                    This page implements <strong>Exercise 1</strong> from the coding test using VB.NET and ASP.NET Web Forms.
                </p>
                <ul>
                    <li>Supports amounts from 0.00 to 999,999.99 pesos</li>
                    <li>Rounds to two decimal places</li>
                    <li>Formats cents as <code>XX/100</code></li>
                    <li>Conversion logic is in <code>Default.aspx.vb</code></li>
                </ul>
            </div>
        </div>
    </main>

</asp:Content>
