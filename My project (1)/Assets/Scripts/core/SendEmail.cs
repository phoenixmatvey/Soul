using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using UnityEngine.UI;
using System;
using System.Globalization;
using System.Text.RegularExpressions;

public class SendEmail : MonoBehaviour
{
    public Text ExamResult;
    public Text Details;
    public InputField To_Adress;
    public Text Flag_sending;

    public void Check_Email()
    {
        Flag_sending.gameObject.SetActive(false);
        try
        {
            Herack_email();
        }
        catch
        {
            Flag_sending.text = "Ошибка!";
            Flag_sending.gameObject.SetActive(true);
        }
    }

    public void Herack_email()
    {
        //Данные почты 
        //Морозов Михаил
        //StudentTestingMMN@gmail.com
        //9H8DTJyseNGiTsx
        MailMessage message_student = new MailMessage();

        MailMessage message = new MailMessage();

        message.Body = ExamResult.text;
        message.Subject = "Тестирование студента програмно";

        message_student.Subject = "Тестирование студента";
        message_student.Body = ExamResult.text;

        message_student.Body += " \n";
        message_student.Body += " \n";
        message_student.Body += " ==============\n";
        message_student.Body += "Детали\n";
        message_student.Body += Details.text;
        message_student.From = new MailAddress("StudentTestingMMN@gmail.com");
        message_student.To.Add("StudentTestingMMN@gmail.com"); 
        message_student.BodyEncoding = System.Text.Encoding.UTF8;

        message.From = new MailAddress("StudentTestingMMN@gmail.com");
        message.To.Add(To_Adress.text);
        message.BodyEncoding = System.Text.Encoding.UTF8;

        SmtpClient client = new SmtpClient();
        client.Host = "smtp.gmail.com";
        client.Port = 587;
        client.Credentials = new NetworkCredential(message_student.From.Address, "9H8DTJyseNGiTsx") as ICredentialsByHost;
        client.DeliveryMethod = SmtpDeliveryMethod.Network;
        client.EnableSsl = true;

        ServicePointManager.ServerCertificateValidationCallback = delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            return true;
        };
        //client.SendCompleted += new SendCompletedEventHandler(MailDeliveryComplete);
        client.Send(message);
        print("OK");
        client.Send(message_student);
        Flag_sending.text = "Успешно";
        Flag_sending.gameObject.SetActive(true);
        print("OK2");
        //client.Send(message);

        //static void MailDeliveryComplete(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        //{
        //    Console.Write("Message \"{0}\".", e.UserState);
        //    if (e.Error != null)
        //        Console.WriteLine("Error sending email.");
        //    else if (e.Cancelled)
        //        Console.WriteLine("Sending of email cancelled.");
        //    else
        //        Console.WriteLine("Message sent.");
        //}
    }
}

