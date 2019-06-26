using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// 这个命名空间是专门放置特殊的枚举类型或结构体。
/// </summary>
namespace SpecialEnumeration
{
    /// <summary>
    /// 在线状态字。
    /// </summary>
    public struct OnlineStatus
    {
        /// <summary>
        /// 上线状态字
        /// </summary>
        public static readonly string Online = ",UP";
        /// <summary>
        /// 下线状态字
        /// </summary>
        public static readonly string Offline = ",DP";
    }

    /// <summary>
    /// 接受状态字。隐含了拒绝的原因。
    /// </summary>
    public struct AcceptStatus
    {
        /// <summary>
        /// 接收文件
        /// </summary>
        public static readonly string Accept = "Accept";
        /// <summary>
        /// 拒绝文件，因为对方主动拒绝或超时未接受
        /// </summary>
        public static readonly string RefuseByUser = "RefuseByUser";
        /// <summary>
        /// 拒绝文件，因为存在文件锁，自动拒绝 
        /// </summary>
        public static readonly string RefuseByLock = "RefuseByLock";
    }

    /// <summary>
    /// 回复状态字。使用时需要 ToString() 。
    /// </summary>
    public enum ReplyStatus
    {
        /// <summary>
        /// 这是询问，需要回复
        /// </summary>
        NeedReply = 1,
        /// <summary>
        /// 不需要回复，或者这本身是回复
        /// </summary>
        NoReplyRequired = 0
    }
}
