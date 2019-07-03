using System;
using System.Management;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;

namespace UChat
{
    /// <summary>
    /// 获取本地主机各种信息。
    /// </summary>
    public class HostInfo
    {
        /// <summary> 
        /// 获取主机名 
        /// </summary> 
        /// <returns></returns> 
        public string HostName
        {
            get
            {
                string hostname = Dns.GetHostName();
                return hostname;
            }
        }

        /// <summary> 
        /// 获取主机 CPU ID。
        /// </summary> 
        /// <returns></returns> 
        public string CPUID
        {
            get
            {
                string cpuInfo = " ";//cpu序列号   
                ManagementClass mc = new ManagementClass("Win32_Processor");
                ManagementObjectCollection moc = mc.GetInstances();
                foreach (ManagementObject mo in moc)
                {
                    cpuInfo = mo.Properties["ProcessorId"].Value.ToString();
                }
                moc = null;
                mc = null;
                return cpuInfo;
            }
        }

        /// <summary> 
        /// 以 IPAddress 格式（原始格式）获取主机活动网络适配器的IPv4地址。
        /// </summary> 
        /// <returns></returns> 
        public IPAddress IPv4Address
        {
            get
            {
                bool found = false;
                IPAddress ipv4 = new IPAddress(0);
                NetworkInterface[] fNetworkInterfaces = NetworkInterface.GetAllNetworkInterfaces();
                foreach (NetworkInterface adapter in fNetworkInterfaces)
                {
                    string fRegistryKey = "SYSTEM\\CurrentControlSet\\Control\\Network\\{4D36E972-E325-11CE-BFC1-08002BE10318}\\" + adapter.Id + "\\Connection";
                    Microsoft.Win32.RegistryKey rk = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(fRegistryKey, false);
                    if (rk != null)
                    {
                        // 区分 PnpInstanceID  注册表项    
                        // 如果前面有 PCI 就是本机的真实网卡          
                        string fPnpInstanceID = rk.GetValue("PnpInstanceID", "").ToString();
                        int fMediaSubType = Convert.ToInt32(rk.GetValue("MediaSubType", 0));
                        if (fPnpInstanceID.Length > 3 && fPnpInstanceID.Substring(0, 3) == "PCI")
                        {
                            if (adapter.NetworkInterfaceType == NetworkInterfaceType.Ethernet && adapter.OperationalStatus == OperationalStatus.Up)//以太网
                            {
                                IPInterfaceProperties iP = adapter.GetIPProperties();//获取网卡接口信息
                                UnicastIPAddressInformationCollection unicastIPs = iP.UnicastAddresses;//获取单播地址表
                                foreach (UnicastIPAddressInformation ipAddress in unicastIPs)
                                {
                                    if (ipAddress.Address.AddressFamily == AddressFamily.InterNetwork)//如果是ipv4地址，ipv6是InterNetworkv6
                                    {
                                        ipv4 = ipAddress.Address;
                                        found = true;
                                    }
                                }
                            }
                            else if (adapter.NetworkInterfaceType == NetworkInterfaceType.Wireless80211 && adapter.OperationalStatus == OperationalStatus.Up)//无线网络
                            {
                                IPInterfaceProperties iP = adapter.GetIPProperties();//获取网卡接口信息
                                UnicastIPAddressInformationCollection unicastIPs = iP.UnicastAddresses;//获取单播地址表
                                foreach (UnicastIPAddressInformation ipAddress in unicastIPs)
                                {
                                    if (ipAddress.Address.AddressFamily == AddressFamily.InterNetwork)//如果是ipv4地址，ipv6是InterNetworkv6
                                    {
                                        ipv4 = ipAddress.Address;
                                        found = true;
                                    }
                                }
                            }
                        }
                    }
                }
                if (found == true)
                {
                    return ipv4;
                }
                else
                {
                    return IPAddress.Parse("0.0.0.0");
                }
            }
        }
    }
}
