using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Text;

namespace Mobile.Servico
{
    public class PingServico
    {
        public static string PingHost(string nameOrAddress)
        {
            Ping pinger = null;

            try
            {
                pinger = new Ping();
                PingReply reply = pinger.Send(nameOrAddress);
                if (reply.Status == IPStatus.Success)
                    return "OK";
                else
                    return reply.Status.ToString();
            }
            catch (PingException ex)
            {
                return ex.Message;
            }
            finally
            {
                if (pinger != null)
                {
                    pinger.Dispose();
                }
            }
        }
    }
}
