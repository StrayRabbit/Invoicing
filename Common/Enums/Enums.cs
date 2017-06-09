using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace Common.Enums
{
    /// <summary>
    /// 枚举独特类
    /// add yuangang by 2016-05-10
    /// </summary>
    public class EnumsClass
    {
        /// <summary>
        /// 枚举value
        /// </summary>
        public int Value { get; set; }
        /// <summary>
        /// 枚举显示值
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 枚举说明
        /// </summary>
        public string Text { get; set; }
    }

    #region 系统管理相关
    /// <summary>
    /// 系统操作枚举
    /// </summary>
    public enum enumOperator
    {
        /// <summary>
        /// 无
        /// </summary>
        [Description("无")]
        None,
        /// <summary>
        /// 查询
        /// </summary>
        [Description("查询")]
        Select,
        /// <summary>
        /// 添加
        /// </summary>
        [Description("添加")]
        Add,
        /// <summary>
        /// 修改
        /// </summary>
        [Description("修改")]
        Edit,
        /// <summary>
        /// 移除
        /// </summary>
        [Description("移除")]
        Remove,
        /// <summary>
        /// 登录
        /// </summary>
        [Description("登录")]
        Login,
        /// <summary>
        /// 登出
        /// </summary>
        [Description("登出")]
        LogOut,
        /// <summary>
        /// 导出
        /// </summary>
        [Description("导出")]
        Export,
        /// <summary>
        /// 导入
        /// </summary>
        [Description("导入")]
        Import,
        /// <summary>
        /// 审核
        /// </summary>
        [Description("审核")]
        Audit,
        /// <summary>
        /// 回复
        /// </summary>
        [Description("回复")]
        Reply,
        /// <summary>
        /// 下载
        /// </summary>
        [Description("下载")]
        Download,
        /// <summary>
        /// 上传
        /// </summary>
        [Description("上传")]
        Upload,
        /// <summary>
        /// 分配
        /// </summary>
        [Description("分配")]
        Allocation,
        /// <summary>
        /// 文件
        /// </summary>
        [Description("文件")]
        Files,
        /// <summary>
        /// 流程
        /// </summary>
        [Description("流程")]
        Flow
    }
    /// <summary>
    /// log4net枚举
    /// </summary>
    public enum enumLog4net
    {
        [Description("普通")]
        INFO,
        [Description("警告")]
        WARN,
        [Description("错误")]
        ERROR,
        [Description("异常")]
        FATAL
    }
    /// <summary>
    /// 模块类别枚举,对应TBSYS_Module表的ModuleType字段
    /// </summary>
    public enum enumModuleType
    {
        无页面 = 1,
        列表页 = 2,
        弹出页 = 3
    }
    /// <summary>
    /// 部门类型
    /// </summary>
    public enum enumDepartmentType
    {
        胜利石油管理局 = 1,
        施工队 = 2,
        工程部 = 3,
        计划科 = 4,
        其他单位 = 5
    }

    #endregion

    #region 流程枚举
    /// <summary>
    /// 流程枚举
    /// </summary>
    public enum FLowEnums
    {
        /// <summary>
        /// 空白
        /// </summary>
        [Description("空白")]
        Blank = 0,
        /// <summary>
        /// 草稿
        /// </summary>
        [Description("草稿")]
        Draft = 1,
        /// <summary>
        /// 运行中
        /// </summary>
        [Description("运行中")]
        Runing = 2,
        /// <summary>
        /// 已完成
        /// </summary>
        [Description("已完成")]
        Complete = 3,
        /// <summary>
        /// 挂起
        /// </summary>
        [Description("挂起")]
        HungUp = 4,
        /// <summary>
        /// 退回
        /// </summary>
        [Description("退回")]
        ReturnSta = 5,
        /// <summary>
        /// 转发(移交)
        /// </summary>
        [Description("移交")]
        Shift = 6,
        /// <summary>
        /// 删除(逻辑删除状态)
        /// </summary>
        [Description("删除")]
        Delete = 7,
        /// <summary>
        /// 加签
        /// </summary>
        [Description("加签")]
        Askfor = 8,
        /// <summary>
        /// 冻结
        /// </summary>
        [Description("冻结")]
        Fix = 9,
        /// <summary>
        /// 批处理
        /// </summary>
        [Description("批处理")]
        Batch = 10,
        /// <summary>
        /// 加签回复状态
        /// </summary>
        [Description("加签回复")]
        AskForReplay = 11
    }
    #endregion

    #region 系统字典

    /// <summary>
    /// 类描述:系统字典
    /// 创建标识:add yuangang by 2016-05-10
    /// </summary>
    public class ClsDic
    {
        /// <summary>
        /// 聊天信息类型
        /// </summary>
        public static Dictionary<string, int> DicMessageType
        {
            get
            {
                return new Dictionary<string, int>
                {
                    {"广播",0},
                    {"群组",1},
                    {"私聊",2}
                };
            }
        }


        /// <summary>
        /// 根据DicKey值获取value
        /// </summary>
        public static string GetDicValueByKey(string key, Dictionary<string, string> p)
        {
            if (p == null || p.Count == 0) return "";
            var dic = p.GetEnumerator();
            while (dic.MoveNext())
            {
                var obj = dic.Current;
                if (key == obj.Key)
                    return obj.Value;
            }
            return "";
        }
        /// <summary>
        /// 根据DICValue获取Key
        /// </summary>
        public static string GetDicKeyByValue(string value, Dictionary<string, string> p)
        {
            if (p == null || p.Count == 0) return "";
            var dic = p.GetEnumerator();
            while (dic.MoveNext())
            {
                var obj = dic.Current;
                if (obj.Value == value)
                    return obj.Key;
            }
            return "";
        }
        /// <summary>
        /// 描述:实体与编码对应字典,在验证数据权限时,通过此处字典来枚举实体编号
        /// <author>创建标识: add yuangang by 2016-05-10</author>
        /// </summary>
        public static Dictionary<string, string> DicEntity
        {
            get
            {
                Dictionary<string, string> _dic = new Dictionary<string, string>();
                _dic.Add("日志", "");
                _dic.Add("用户", "18da4207-3bfc-49ea-90f7-16867721805c");
                return _dic;
            }
        }
        /// <summary>
        /// 描述:存放特别的角色编号字典,在验证操作权限时用到
        /// 创建标识:add by liuj 2013-8-9 9:56
        /// </summary>
        public static Dictionary<string, int> DicRole
        {
            get
            {
                Dictionary<string, int> _dic = new Dictionary<string, int>();
                _dic.Add("超级管理员", 1);
                return _dic;
            }
        }
        /// <summary>
        /// 字典类型
        /// </summary>
        public static Dictionary<string, string> DicCodeType
        {
            get
            {
                Dictionary<string, string> _dic = new Dictionary<string, string>();

                string dicStr = "职务-ZW,在岗状态-ZGZT,婚姻状况-HYZK,学历-XL,政治面貌-ZZMM,民族-MZ,职称-ZC,业务授权-YWSQ,岗位类型-POSTTYPE,权限值-ROLEVALUE,员工级别-YGJB,合同类型-HTLB,合同状态-HTZT,客户分类-KHFL,IP类型-IPLX,项目类型-XMLX,项目状态-XMZT,成本类别-CBLB,任务状态-RWZT,任务类别-RWLB,任务阶段-RWJD,日志类别-RZLB,文章类别-WZLB,流程状态-WZZT,优先级-YXJ,联系人类型-LXRLX,消息类型-XXLX";
                var diclist = dicStr.TrimEnd(',').TrimStart(',').Split(',').ToList();
                if (diclist.Count > 0)
                {
                    foreach (var item in diclist)
                    {
                        _dic.Add(item.Split('-')[0], item.Split('-')[1]);
                    }
                }

                return _dic;
            }
        }
        /// <summary>
        /// 附件上传路径
        /// 创建标识:add yuangang by 2016-05-10
        /// </summary>
        public static Dictionary<string, string> DicAttachmentPath
        {
            get
            {
                Dictionary<string, string> _dic = new Dictionary<string, string>();
                _dic.Add("上传路径", System.Configuration.ConfigurationManager.AppSettings["upfile"]);
                _dic.Add("档案简历", System.Configuration.ConfigurationManager.AppSettings["upfile"]);
                _dic.Add("手机文件", System.Configuration.ConfigurationManager.AppSettings["upphone"]);
                _dic.Add("手机照片", System.Configuration.ConfigurationManager.AppSettings["photofile"]);
                _dic.Add("技术文件", System.Configuration.ConfigurationManager.AppSettings["upTsfile"]);
                _dic.Add("工程图", System.Configuration.ConfigurationManager.AppSettings["UploadFiles"]);
                _dic.Add("档案头像", System.Configuration.ConfigurationManager.AppSettings["upfile"]);
                return _dic;
            }
        }
        /// <summary>
        /// 业务办理图片宽高
        /// 创建标识:add yuangang by 2016-05-10
        /// </summary>
        public static Dictionary<string, string> DicImageWH
        {
            get
            {
                Dictionary<string, string> _dic = new Dictionary<string, string>();
                _dic.Add("图片宽度", System.Configuration.ConfigurationManager.AppSettings["imgWidth"]);
                _dic.Add("图片高度", System.Configuration.ConfigurationManager.AppSettings["imgHeight"]);
                _dic.Add("手机用户头像高", System.Configuration.ConfigurationManager.AppSettings["UserPhotoHeight"]);
                _dic.Add("手机用户头像宽", System.Configuration.ConfigurationManager.AppSettings["UserPhotoWidth"]);
                _dic.Add("用户头像高", System.Configuration.ConfigurationManager.AppSettings["PolicePhotoHeight"]);
                _dic.Add("用户头像宽", System.Configuration.ConfigurationManager.AppSettings["PolicePhotoWidth"]);
                return _dic;
            }
        }
        /// <summary>
        /// 警务室图片宽高
        /// 创建标识:add yuangang by 2016-05-10
        /// </summary>
        public static Dictionary<string, string> DicPoliceHouseImageWH
        {
            get
            {
                Dictionary<string, string> _dic = new Dictionary<string, string>();
                _dic.Add("图片宽度", System.Configuration.ConfigurationManager.AppSettings["imgPoliceWidth"]);
                _dic.Add("图片高度", System.Configuration.ConfigurationManager.AppSettings["imgPoliceHeight"]);
                return _dic;
            }
        }
        /// <summary>
        /// OracleReportData
        /// 创建标识:add yuangang by 2016-05-10
        /// </summary>
        public static Dictionary<string, string> OracleReportData
        {
            get
            {
                Dictionary<string, string> _dic = new Dictionary<string, string>();
                _dic.Add("OrcalReport", System.Configuration.ConfigurationManager.AppSettings["connectionString"]);
                return _dic;
            }
        }
        /// <summary>
        /// 手机客户端命名
        /// 创建标识:add yuangang by 2016-05-10
        /// </summary>
        public static Dictionary<string, string> DicPhone
        {
            get
            {
                Dictionary<string, string> _dic = new Dictionary<string, string>();
                _dic.Add("安卓程序", System.Configuration.ConfigurationManager.AppSettings["AndroidName"]);
                _dic.Add("苹果程序", System.Configuration.ConfigurationManager.AppSettings["IOSName"]);
                return _dic;
            }
        }
        /// <summary>
        /// 功能描述：记录Cookie的Key值 
        /// 创建标识：徐戈
        /// </summary>
        public static Dictionary<string, string> DicCookie
        {
            get
            {
                Dictionary<string, string> _dic = new Dictionary<string, string>();
                _dic.Add("Session中存储的帐号和CookieID", "AccountCookieID_Session");
                _dic.Add("Cookie中存储的帐号和CookieID", "AccountCookieIDNew");
                return _dic;
            }
        }
        /// <summary>
        /// 功能描述：记录Cookie的Key值 
        /// 创建标识：徐戈
        /// </summary>
        public static Dictionary<string, string> DicCookieTimeout
        {
            get
            {
                Dictionary<string, string> _dic = new Dictionary<string, string>();
                _dic.Add("帐号过期时间", "30");
                return _dic;
            }
        }


        public static Dictionary<string, int> DicProject
        {
            get
            {
                return new Dictionary<string, int>
                {
                    {
                        "准备中",
                        0
                    },
                    {
                        "进行中",
                        1
                    },
                    {
                        "延期",
                        2
                    },
                    {
                        "已超时",
                        3
                    },
                    {
                        "已终止",
                        4
                    },
                    {
                        "已验收",
                        5
                    },
                    {
                        "已完成",
                        6
                    },
                    {
                        "已失败",
                        7
                    },
                    {
                        "已违约",
                        8
                    },
                    {
                        "对方违约",
                        9
                    }
                };
            }
        }

        public static System.Collections.Generic.Dictionary<string, int> DicStatus
        {
            get
            {
                return new System.Collections.Generic.Dictionary<string, int>
                {
                    {
                        "驳回",
                        0
                    },
                    {
                        "通过",
                        1
                    },
                    {
                        "等待审核",
                        2
                    }
                };
            }
        }
    }
    #endregion

    #region 业务相关
    /// <summary>
    /// 计划流转状态
    /// </summary>
    public enum enumHCA_RecognitionProgramProcessType
    {
        上报 = 1,
        同意 = 2,
        不同意 = 3
    }
    /// <summary>
    /// 上传文件类型
    /// </summary>
    public enum enumFileType
    {
        其他 = 0,
        Word = 1,
        Excel = 2,
        图片 = 3,
        PPT = 4,
        PDF = 5,
        RAR = 6
    }
    /// <summary>
    ///路单状态
    /// </summary>
    public enum enumWAYBILLSTATE
    {
        分派 = 1,
        打印 = 2,
        数据录入 = 3,
        数据填报 = 4,
        车队审核回收 = 5,
        删除 = 6,
        作废 = 7,
        交接 = 8,
        纳入结算 = 9,
        完成结算 = 10


    }
    /// <summary>
    /// 来源
    /// </summary>
    public enum enumORIGIN
    {
        自建 = 1,
        任务 = 2,
        外委申请 = 3
    }

    /// <summary>
    /// 应急物资规格型号
    /// </summary>
    public enum enumReliefGoodsModel
    {
        规格型号1 = 1,
        规格型号2 = 2,
        规格型号3 = 3
    }
    /// <summary>
    /// 应急抢险救援物资类别
    /// </summary>
    public enum enumReliefGoodsType
    {
        溢油 = 1,
        防汛 = 2
    }
    /// <summary>
    /// 业务咨询枚举,对应业务咨询表的bptype字段
    /// </summary>
    public enum enumBptType
    {
        在线咨询 = 401002,
        身份证 = 501001,
        户籍 = 501002,
        治安管理 = 501003,
        出入境 = 501004,
        消防 = 501005,
        其他业务 = 501006,
        交警 = 501007,
        网安 = 501008,
        法制 = 501009
    }

    public enum enumNewsType
    {
        警务信息 = 301001,
        警方公告 = 301002,
        防范提示 = 101501
    }

    /// <summary>
    /// 上传文件类型
    /// </summary>
    public enum enumBusType
    {

        车辆图片上传 = 100001,
        套管图片上传 = 103002,
        三通图片上传 = 103003,
        阀门图片上传 = 103004,
        占压图片上传 = 103005,


    }


    /// <summary>
    /// 管道维修应急预案级别
    /// </summary>
    public enum enumEmergencyPlanLevel
    {
        中石化 = 1,
        油田 = 2,
        总厂 = 3,
        分厂 = 4
    }

    /// <summary>
    /// 阳极材料
    /// </summary>
    public enum enumAnodeMaterial
    {
        未知 = 0,
        镀铂阳极 = 1,
        磁性氧化铁 = 2,
        混合金属氧化物 = 3,
        镁 = 4,
        锌 = 5,
        铂 = 6,
        高硅铸铁 = 7,
        石墨 = 8,
        废钢铁 = 9,
        碳 = 10,
        铝合金 = 11,
        其它 = 99
    }


    /// <summary>
    /// 业务咨询处理状态枚举,对应业务咨询表的requesStatus字段
    /// </summary>
    public enum enumBussinessType
    {
        后台办理本部门业务 = 1,
        手机办理本部门业务 = 2,
        手机业务 = 3,
        社区民警 = 4
    }

    /// <summary>
    /// 业务咨询处理状态枚举,对应业务咨询表的requesStatus字段
    /// </summary>
    public enum enumRequesStatus
    {
        用户提交 = 0,
        指定处理 = 1,
        处理完成 = 2
    }

    public enum enumWorkType
    {
        未指定 = -1,
        手机方式 = 0,
        电脑Web = 1
    }
    public enum enumIsBool
    {
        是 = 1,
        否 = 2
    }

    public enum enumPhoneUserType
    {
        注册用户 = 1,
        匿名用户 = 2
    }

    public enum enumReplyType
    {
        未处理 = 0,
        审核通过 = 1,
        审核不通过 = 2
    }

    public enum enumBlogType
    {
        新浪微博 = 0,
        腾讯微博 = 1,
        东营公安局的腾讯微博 = 2
    }


    #endregion

}