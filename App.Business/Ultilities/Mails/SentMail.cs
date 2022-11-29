﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Spire.Email;
using Spire.Email.IMap;
using Spire.Email.Smtp;
using MailMessage = Spire.Email.MailMessage;
using SmtpClient = Spire.Email.Smtp.SmtpClient;
using MailAddress = Spire.Email.MailAddress;
namespace App.Business.Ultilities.Mails
{
    public class SentMail
    {
        public static string SendMailGoogleSmtp(string _from, string _to, string _subject,
            string body, string gmailsend, string gmailpassword)
        {
            MailAddress addressFrom = new(_from, "EGALE SHOP");
            MailAddress addressTo = new(_to);
            MailMessage message = new(addressFrom, addressTo)
            {
                Date = DateTime.Now,
                Subject = _subject
            };

            #region EmailBody

            string htmlString = @"<!DOCTYPE HTML PUBLIC ""-//W3C//DTD XHTML 1.0 Transitional //EN"" ""http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd"">
<html xmlns=""http://www.w3.org/1999/xhtml"" xmlns:v=""urn:schemas-microsoft-com:vml"" xmlns:o=""urn:schemas-microsoft-com:office:office"">
<head>
  <meta http-equiv=""Content-Type"" content=""text/html; charset=UTF-8"">
  <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
  <meta name=""x-apple-disable-message-reformatting"">
  <meta http-equiv=""X-UA-Compatible"" content=""IE=edge"">
  <title></title>
  <style type=""text/css"">
    @media only screen and (min-width: 620px) {
      .u-row {
        width: 600px !important;
      }
      .u-row .u-col {
        vertical-align: top;
      }
      .u-row .u-col-100 {
        width: 600px !important;
      }
    }
    
    @media (max-width: 620px) {
      .u-row-container {
        max-width: 100% !important;
        padding-left: 0px !important;
        padding-right: 0px !important;
      }
      .u-row .u-col {
        min-width: 320px !important;
        max-width: 100% !important;
        display: block !important;
      }
      .u-row {
        width: calc(100% - 40px) !important;
      }
      .u-col {
        width: 100% !important;
      }
      .u-col>div {
        margin: 0 auto;
      }
    }
    
    body {
      margin: 0;
      padding: 0;
    }
    
    table,
    tr,
    td {
      vertical-align: top;
      border-collapse: collapse;
    }
    
    p {
      margin: 0;
    }
    
    .ie-container table,
    .mso-container table {
      table-layout: fixed;
    }
    
    * {
      line-height: inherit;
    }
    
    a[x-apple-data-detectors='true'] {
      color: inherit !important;
      text-decoration: none !important;
    }
    
    table,
    td {
      color: #000000;
    }
    
    a {
      color: #0000ee;
      text-decoration: underline;
    }
  </style>
  <link href=""https://fonts.googleapis.com/css?family=Cabin:400,700"" rel=""stylesheet"" type=""text/css"">
</head>
<body class=""clean-body u_body"" style=""margin: 0;padding: 0;-webkit-text-size-adjust: 100%;background-color: #f9f9f9;color: #000000"">
  <table style=""border-collapse: collapse;table-layout: fixed;border-spacing: 0;mso-table-lspace: 0pt;mso-table-rspace: 0pt;vertical-align: top;min-width: 320px;Margin: 0 auto;background-color: #f9f9f9;width:100%"" cellpadding=""0"" cellspacing=""0"">
    <tbody>
      <tr style=""vertical-align: top"">
        <td style=""word-break: break-word;border-collapse: collapse !important;vertical-align: top"">
          <div class=""u-row-container"" style=""padding: 0px;background-color: transparent"">
            <div class=""u-row"" style=""Margin: 0 auto;min-width: 320px;max-width: 600px;overflow-wrap: break-word;word-wrap: break-word;word-break: break-word;background-color: transparent;"">
              <div style=""border-collapse: collapse;display: table;width: 100%;height: 100%;background-color: transparent;"">
                <div class=""u-col u-col-100"" style=""max-width: 320px;min-width: 600px;display: table-cell;vertical-align: top;"">
                  <div style=""height: 100%;width: 100% !important;"">
                    <div style=""padding: 0px;border-top: 0px solid transparent;border-left: 0px solid transparent;border-right: 0px solid transparent;border-bottom: 0px solid transparent;"">
                      <table style=""font-family:'Cabin',sans-serif;"" role=""presentation"" cellpadding=""0"" cellspacing=""0"" width=""100%"" border=""0"">
                        <tbody>
                          <tr>
                            <td style=""overflow-wrap:break-word;word-break:break-word;padding:10px;font-family:'Cabin',sans-serif;"" align=""left"">
                              <div style=""color: #afb0c7; line-height: 170%; text-align: center; word-wrap: break-word;"">
                              </div>
                            </td>
                          </tr>
                        </tbody>
                      </table>
                        </div>
                  </div>
                </div>
              </div>
            </div>
          </div>
            <div class=""u-row-container"" style=""padding: 0px;background-color: transparent"">
            <div class=""u-row"" style=""Margin: 0 auto;min-width: 320px;max-width: 600px;overflow-wrap: break-word;word-wrap: break-word;word-break: break-word;background-color: #ffffff;"">
              <div style=""border-collapse: collapse;display: table;width: 100%;height: 100%;background-color: transparent;"">
                <div class=""u-col u-col-100"" style=""max-width: 320px;min-width: 600px;display: table-cell;vertical-align: top;"">
                  <div style=""height: 100%;width: 100% !important;"">
                    <div style=""padding: 0px;border-top: 0px solid transparent;border-left: 0px solid transparent;border-right: 0px solid transparent;border-bottom: 0px solid transparent;"">
                      <table style=""font-family:'Cabin',sans-serif;"" role=""presentation"" cellpadding=""0"" cellspacing=""0"" width=""100%"" border=""0"">
                        <tbody>
                          <tr>
                            <td style=""overflow-wrap:break-word;word-break:break-word;padding:20px;font-family:'Cabin',sans-serif;"" align=""left"">
                              <table width=""100%"" cellpadding=""0"" cellspacing=""0"" border=""0"">
                                <tr>
                                  <td style=""padding-right: 0px;padding-left: 0px;"" align=""center"">
                                    <img align=""center"" border=""0"" src=""https://assets.unlayer.com/projects/90252/1657971166146-Logo%20(1).png"" alt=""Image"" title=""Image"" style=""outline: none;text-decoration: none;-ms-interpolation-mode: bicubic;clear: both;display: inline-block !important;border: none;height: auto;float: none;width: 32%;max-width: 179.2px;""
                                      width=""179.2"" />
                                  </td>
                                </tr>
                              </table>
                            </td>
                          </tr>
                        </tbody>
                      </table>
                    </div>
                  </div>
                </div>
              </div>
            </div>
          </div>
          <div class=""u-row-container"" style=""padding: 0px;background-color: transparent"">
            <div class=""u-row"" style=""Margin: 0 auto;min-width: 320px;max-width: 600px;overflow-wrap: break-word;word-wrap: break-word;word-break: break-word;background-color: #003399;"">
              <div style=""border-collapse: collapse;display: table;width: 100%;height: 100%;background-color: transparent;"">
                <div class=""u-col u-col-100"" style=""max-width: 320px;min-width: 600px;display: table-cell;vertical-align: top;"">
                  <div style=""height: 100%;width: 100% !important;"">
                    <div style=""padding: 0px;border-top: 0px solid transparent;border-left: 0px solid transparent;border-right: 0px solid transparent;border-bottom: 0px solid transparent;"">
                      <table style=""font-family:'Cabin',sans-serif;"" role=""presentation"" cellpadding=""0"" cellspacing=""0"" width=""100%"" border=""0"">
                        <tbody>
                          <tr>
                            <td style=""overflow-wrap:break-word;word-break:break-word;padding:40px 10px 10px;font-family:'Cabin',sans-serif;"" align=""left"">
                              <table width=""100%"" cellpadding=""0"" cellspacing=""0"" border=""0"">
                                <tr>
                                  <td style=""padding-right: 0px;padding-left: 0px;"" align=""center"">
                                    <img align=""center"" border=""0"" src=""https://cdn.templates.unlayer.com/assets/1597218650916-xxxxc.png"" alt=""Image"" title=""Image"" style=""outline: none;text-decoration: none;-ms-interpolation-mode: bicubic;clear: both;display: inline-block !important;border: none;height: auto;float: none;width: 26%;max-width: 150.8px;""
                                      width=""150.8"" />
                                  </td>
                                </tr>
                              </table>
                            </td>
                          </tr>
                        </tbody>
                      </table>
                      <table style=""font-family:'Cabin',sans-serif;"" role=""presentation"" cellpadding=""0"" cellspacing=""0"" width=""100%"" border=""0"">
                        <tbody>
                          <tr>
                            <td style=""overflow-wrap:break-word;word-break:break-word;padding:10px;font-family:'Cabin',sans-serif;"" align=""left"">
                              <div style=""color: #e5eaf5; line-height: 140%; text-align: center; word-wrap: break-word;"">
                                <p style=""font-size: 14px; line-height: 140%;""><strong>X I N S&nbsp; &nbsp;C Ả M&nbsp; &nbsp;Ơ N   Đ Ã&nbsp; &nbsp;S Ử  D Ụ N G !</strong></p>
                              </div>
                            </td>
                          </tr>
                        </tbody>
                      </table>
                      <table style=""font-family:'Cabin',sans-serif;"" role=""presentation"" cellpadding=""0"" cellspacing=""0"" width=""100%"" border=""0"">
                        <tbody>
                          <tr>
                            <td style=""overflow-wrap:break-word;word-break:break-word;padding:0px 10px 31px;font-family:'Cabin',sans-serif;"" align=""left"">
                              <div style=""color: #e5eaf5; line-height: 140%; text-align: center; word-wrap: break-word;"">
                                <p style=""font-size: 14px; line-height: 140%;""><span style=""font-size: 28px; line-height: 39.2px;""><strong><span style=""line-height: 39.2px; font-size: 28px;"">Vui lòng xác nhận email của bạn ! </span></strong>
                                  </span>
                                </p>
                              </div>
                            </td>
                          </tr>
                        </tbody>
                      </table>
                        
                    </div>
                  </div>
                </div>
              </div>
            </div>
          </div>
          <div class=""u-row-container"" style=""padding: 0px;background-color: transparent"">
            <div class=""u-row"" style=""Margin: 0 auto;min-width: 320px;max-width: 600px;overflow-wrap: break-word;word-wrap: break-word;word-break: break-word;background-color: #ffffff;"">
              <div style=""border-collapse: collapse;display: table;width: 100%;height: 100%;background-color: transparent;"">
                <div class=""u-col u-col-100"" style=""max-width: 320px;min-width: 600px;display: table-cell;vertical-align: top;"">
                  <div style=""height: 100%;width: 100% !important;"">
                    <div style=""padding: 0px;border-top: 0px solid transparent;border-left: 0px solid transparent;border-right: 0px solid transparent;border-bottom: 0px solid transparent;"">
                      <table style=""font-family:'Cabin',sans-serif;"" role=""presentation"" cellpadding=""0"" cellspacing=""0"" width=""100%"" border=""0"">
                        <tbody>
                          <tr>
                            <td style=""overflow-wrap:break-word;word-break:break-word;padding:33px 55px;font-family:'Cabin',sans-serif;"" align=""left"">
                              <div style=""line-height: 160%; text-align: center; word-wrap: break-word;"">
                                <p style=""line-height: 160%; font-size: 14px;""><span style=""font-size: 22px; line-height: 35.2px;"">" + body + @"</span></p>
                              </div>
                            </td>
                          </tr>
                        </tbody>
                      </table>
                      <table style=""font-family:'Cabin',sans-serif;"" role=""presentation"" cellpadding=""0"" cellspacing=""0"" width=""100%"" border=""0"">
                        <tbody>
                          <tr>
                            <td style=""overflow-wrap:break-word;word-break:break-word;padding:10px;font-family:'Cabin',sans-serif;"" align=""left"">
                              <div align=""center"">
          <a href="""" target=""_blank"" style=""box-sizing: border-box;display: inline-block;font-family:'Cabin',sans-serif;text-decoration: none;-webkit-text-size-adjust: none;text-align: center;color: #FFFFFF; background-color: #ff6600; border-radius: 4px;-webkit-border-radius: 4px; -moz-border-radius: 4px; width:auto; max-width:100%; overflow-wrap: break-word; word-break: break-word; word-wrap:break-word; mso-border-alt: none;"">
                                  <span style=""display:block;padding:14px 44px 13px;line-height:120%;""><span style=""font-size: 16px; line-height: 19.2px;""><strong><span style=""line-height: 19.2px; font-size: 16px;"">VERIFY YOUR EMAIL</span></strong>
                                  </span>
                                  </span>
                                </a>
                              </div>
                            </td>
                          </tr>
                        </tbody>
                      </table>
                      <table style=""font-family:'Cabin',sans-serif;"" role=""presentation"" cellpadding=""0"" cellspacing=""0"" width=""100%"" border=""0"">
                        <tbody>
                          <tr>
                            <td style=""overflow-wrap:break-word;word-break:break-word;padding:33px 55px 60px;font-family:'Cabin',sans-serif;"" align=""left"">
                              <div style=""line-height: 160%; text-align: center; word-wrap: break-word;"">
                                <p style=""line-height: 160%; font-size: 14px;""><span style=""font-size: 18px; line-height: 28.8px;"">Xin cảm ơn,</span></p>
                                <p style=""line-height: 160%; font-size: 14px;""><span style=""font-size: 18px; line-height: 28.8px;"">Chúng tôi là EGALE SHOP</span></p>
<p style=""line-height: 160%; font-size: 14px;""><span style=""font-size: 18px; line-height: 28.8px;"">“Fashions fade, style is eternal”– Yves Saint Laurent.</span></p>
                              </div>
                            </td>
                          </tr>
                        </tbody>
                      </table>
                    </div>
                  </div>
                </div>
              </div>
            </div>
          </div>
          <div class=""u-row-container"" style=""padding: 0px;background-color: transparent"">
            <div class=""u-row"" style=""Margin: 0 auto;min-width: 320px;max-width: 600px;overflow-wrap: break-word;word-wrap: break-word;word-break: break-word;background-color: #e5eaf5;"">
              <div style=""border-collapse: collapse;display: table;width: 100%;height: 100%;background-color: transparent;"">
                <div class=""u-col u-col-100"" style=""max-width: 320px;min-width: 600px;display: table-cell;vertical-align: top;"">
                  <div style=""height: 100%;width: 100% !important;"">
                    <div style=""padding: 0px;border-top: 0px solid transparent;border-left: 0px solid transparent;border-right: 0px solid transparent;border-bottom: 0px solid transparent;"">
                    
                      <table style=""font-family:'Cabin',sans-serif;"" role=""presentation"" cellpadding=""0"" cellspacing=""0"" width=""100%"" border=""0"">
                        <tbody>
                          <tr>
                            <td style=""overflow-wrap:break-word;word-break:break-word;padding:41px 55px 18px;font-family:'Cabin',sans-serif;"" align=""left"">
                              <div style=""color: #003399; line-height: 160%; text-align: center; word-wrap: break-word;"">
                                <p style=""font-size: 14px; line-height: 160%;""><span style=""font-size: 20px; line-height: 32px;""><strong>Get in touch</strong></span></p>
                                <p style=""font-size: 14px; line-height: 160%;""><span style=""font-size: 16px; line-height: 25.6px; color: #000000;"">+84 976 909 518</span></p>
                                <p style=""font-size: 14px; line-height: 160%;""><span style=""font-size: 16px; line-height: 25.6px; color: #000000;"">tungtdph16451@fpt.edu.vn</span></p>
                              </div>
                            </td>
                          </tr>
                        </tbody>
                      </table>
                      <table style=""font-family:'Cabin',sans-serif;"" role=""presentation"" cellpadding=""0"" cellspacing=""0"" width=""100%"" border=""0"">
                        <tbody>
                          <tr>
                            <td style=""overflow-wrap:break-word;word-break:break-word;padding:10px 10px 33px;font-family:'Cabin',sans-serif;"" align=""left"">
                              <div align=""center"">
                                <div style=""display: table; max-width:244px;"">
                                  <table align=""left"" border=""0"" cellspacing=""0"" cellpadding=""0"" width=""32"" height=""32"" style=""width: 32px !important;height: 32px !important;display: inline-block;border-collapse: collapse;table-layout: fixed;border-spacing: 0;mso-table-lspace: 0pt;mso-table-rspace: 0pt;vertical-align: top;margin-right: 17px"">
                                    <tbody>
                                      <tr style=""vertical-align: top"">
                                        <td align=""left"" valign=""middle"" style=""word-break: break-word;border-collapse: collapse !important;vertical-align: top"">
                                          <a href=""https://facebook.com/"" title=""Facebook"" target=""_blank"">
                                            <img src=""https://cdn.tools.unlayer.com/social/icons/circle-black/facebook.png"" alt=""Facebook"" title=""Facebook"" width=""32"" style=""outline: none;text-decoration: none;-ms-interpolation-mode: bicubic;clear: both;display: block !important;border: none;height: auto;float: none;max-width: 32px !important"">
                                          </a>
                                        </td>
                                      </tr>
                                    </tbody>
                                  </table>
                                  <table align=""left"" border=""0"" cellspacing=""0"" cellpadding=""0"" width=""32"" height=""32"" style=""width: 32px !important;height: 32px !important;display: inline-block;border-collapse: collapse;table-layout: fixed;border-spacing: 0;mso-table-lspace: 0pt;mso-table-rspace: 0pt;vertical-align: top;margin-right: 17px"">
                                    <tbody>
                                      <tr style=""vertical-align: top"">
                                        <td align=""left"" valign=""middle"" style=""word-break: break-word;border-collapse: collapse !important;vertical-align: top"">
                                          <a href=""https://linkedin.com/"" title=""LinkedIn"" target=""_blank"">
                                            <img src=""https://cdn.tools.unlayer.com/social/icons/circle-black/linkedin.png"" alt=""LinkedIn"" title=""LinkedIn"" width=""32"" style=""outline: none;text-decoration: none;-ms-interpolation-mode: bicubic;clear: both;display: block !important;border: none;height: auto;float: none;max-width: 32px !important"">
                                          </a>
                                        </td>
                                      </tr>
                                    </tbody>
                                  </table>
                                  <table align=""left"" border=""0"" cellspacing=""0"" cellpadding=""0"" width=""32"" height=""32"" style=""width: 32px !important;height: 32px !important;display: inline-block;border-collapse: collapse;table-layout: fixed;border-spacing: 0;mso-table-lspace: 0pt;mso-table-rspace: 0pt;vertical-align: top;margin-right: 17px"">
                                    <tbody>
                                      <tr style=""vertical-align: top"">
                                        <td align=""left"" valign=""middle"" style=""word-break: break-word;border-collapse: collapse !important;vertical-align: top"">
                                          <a href=""https://instagram.com/"" title=""Instagram"" target=""_blank"">
                                            <img src=""https://cdn.tools.unlayer.com/social/icons/circle-black/instagram.png"" alt=""Instagram"" title=""Instagram"" width=""32"" style=""outline: none;text-decoration: none;-ms-interpolation-mode: bicubic;clear: both;display: block !important;border: none;height: auto;float: none;max-width: 32px !important"">
                                          </a>
                                        </td>
                                      </tr>
                                    </tbody>
                                  </table>
                                  <table align=""left"" border=""0"" cellspacing=""0"" cellpadding=""0"" width=""32"" height=""32"" style=""width: 32px !important;height: 32px !important;display: inline-block;border-collapse: collapse;table-layout: fixed;border-spacing: 0;mso-table-lspace: 0pt;mso-table-rspace: 0pt;vertical-align: top;margin-right: 17px"">
                                    <tbody>
                                      <tr style=""vertical-align: top"">
                                        <td align=""left"" valign=""middle"" style=""word-break: break-word;border-collapse: collapse !important;vertical-align: top"">
                                          <a href=""https://youtube.com/"" title=""YouTube"" target=""_blank"">
                                            <img src=""https://cdn.tools.unlayer.com/social/icons/circle-black/youtube.png"" alt=""YouTube"" title=""YouTube"" width=""32"" style=""outline: none;text-decoration: none;-ms-interpolation-mode: bicubic;clear: both;display: block !important;border: none;height: auto;float: none;max-width: 32px !important"">
                                          </a>
                                        </td>
                                      </tr>
                                    </tbody>
                                  </table>
                                  <table align=""left"" border=""0"" cellspacing=""0"" cellpadding=""0"" width=""32"" height=""32"" style=""width: 32px !important;height: 32px !important;display: inline-block;border-collapse: collapse;table-layout: fixed;border-spacing: 0;mso-table-lspace: 0pt;mso-table-rspace: 0pt;vertical-align: top;margin-right: 0px"">
                                    <tbody>
                                      <tr style=""vertical-align: top"">
                                        <td align=""left"" valign=""middle"" style=""word-break: break-word;border-collapse: collapse !important;vertical-align: top"">
                                          <a href=""https://email.com/"" title=""Email"" target=""_blank"">
                                            <img src=""https://cdn.tools.unlayer.com/social/icons/circle-black/email.png"" alt=""Email"" title=""Email"" width=""32"" style=""outline: none;text-decoration: none;-ms-interpolation-mode: bicubic;clear: both;display: block !important;border: none;height: auto;float: none;max-width: 32px !important"">
                                          </a>
                                        </td>
                                      </tr>
                                    </tbody>
                                  </table>
                                </div>
                              </div>
                            </td>
                          </tr>
                        </tbody>
                      </table>
                    </div>
                  </div>
                </div>
              </div>
            </div>
          </div>
          <div class=""u-row-container"" style=""padding: 0px;background-color: transparent"">
            <div class=""u-row"" style=""Margin: 0 auto;min-width: 320px;max-width: 600px;overflow-wrap: break-word;word-wrap: break-word;word-break: break-word;background-color: #003399;"">
              <div style=""border-collapse: collapse;display: table;width: 100%;height: 100%;background-color: transparent;"">
                <div class=""u-col u-col-100"" style=""max-width: 320px;min-width: 600px;display: table-cell;vertical-align: top;"">
                  <div style=""height: 100%;width: 100% !important;"">
                    <div style=""padding: 0px;border-top: 0px solid transparent;border-left: 0px solid transparent;border-right: 0px solid transparent;border-bottom: 0px solid transparent;"">
                      <table style=""font-family:'Cabin',sans-serif;"" role=""presentation"" cellpadding=""0"" cellspacing=""0"" width=""100%"" border=""0"">
                        <tbody>
                          <tr>
                            <td style=""overflow-wrap:break-word;word-break:break-word;padding:10px;font-family:'Cabin',sans-serif;"" align=""left"">
                              <div style=""color: #fafafa; line-height: 180%; text-align: center; word-wrap: break-word;"">
                                <p style=""font-size: 14px; line-height: 180%;""><span style=""font-size: 16px; line-height: 28.8px;"">Copyrights &copy; Company All Rights Reserved</span></p>
                              </div>
                            </td>
                          </tr>
                        </tbody>
                      </table>
                        
                    </div>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </td>
      </tr>
    </tbody>
  </table>
</body>
</html>
                     ";

            #endregion

            message.BodyHtml = htmlString;

            SmtpClient client = new()
            {
                Host = "smtp.gmail.com",
                Port = 587,
                Username = gmailsend,
                Password = gmailpassword,
                ConnectionProtocols = ConnectionProtocols.Ssl
            };
            try
            {
                client.SendOne(message);
                return "Gửi mã xác nhận thành công, mã xác nhận sẽ gửi vào mail mới của bạn vui lòng kiểm tra !";
            }
            catch
            {
                return "Gửi mã thất bại !";
            }
        }
    }
}
