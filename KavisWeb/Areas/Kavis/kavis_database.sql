USE [KavisWeb.DataLayer.StrategyDBContext]
GO
/****** Object:  Table [dbo].[burbis_11_Amaclar]    Script Date: 15.11.2021 14:33:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[burbis_11_Amaclar](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[StratejikPlanId] [int] NOT NULL,
	[Kod] [nvarchar](max) NULL,
	[Baslik] [nvarchar](max) NULL,
	[SiraNo] [int] NOT NULL,
 CONSTRAINT [PK_dbo.burbis_11_Amaclar] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[burbis_11_Birimler]    Script Date: 15.11.2021 14:33:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[burbis_11_Birimler](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BurbisId] [int] NOT NULL,
	[Kodu] [nvarchar](max) NULL,
	[Baslik] [nvarchar](max) NULL,
	[KurumId] [int] NULL,
 CONSTRAINT [PK_dbo.burbis_11_Birimler] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[burbis_11_Eylemler]    Script Date: 15.11.2021 14:33:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[burbis_11_Eylemler](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Birim] [nvarchar](max) NULL,
	[StratejiId] [int] NOT NULL,
	[Kod] [nvarchar](max) NULL,
	[Baslik] [nvarchar](max) NULL,
	[SiraNo] [int] NOT NULL,
 CONSTRAINT [PK_dbo.burbis_11_Eylemler] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[burbis_11_Faaliyetler]    Script Date: 15.11.2021 14:33:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[burbis_11_Faaliyetler](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[EylemId] [int] NOT NULL,
	[Baslama] [datetime] NULL,
	[Bitis] [datetime] NULL,
	[Gerceklesme] [nvarchar](max) NULL,
	[Sonuc] [nvarchar](max) NULL,
	[Durum] [nvarchar](max) NULL,
	[Birim] [int] NOT NULL,
	[Kod] [nvarchar](max) NULL,
	[Baslik] [nvarchar](max) NULL,
	[SiraNo] [int] NOT NULL,
	[BirimAdi] [nvarchar](max) NULL,
	[Yil] [tinyint] NOT NULL,
	[Onay1] [bit] NOT NULL,
	[Onay2] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.burbis_11_Faaliyetler] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[burbis_11_GostergeGirisleri]    Script Date: 15.11.2021 14:33:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[burbis_11_GostergeGirisleri](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[GostergeId] [int] NOT NULL,
	[Yil] [tinyint] NOT NULL,
	[BirimId] [int] NOT NULL,
	[Onay] [bit] NOT NULL,
	[Deger] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.burbis_11_GostergeGirisleri] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[burbis_11_Gostergeler]    Script Date: 15.11.2021 14:33:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[burbis_11_Gostergeler](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[HedefeEtkisi] [nvarchar](max) NULL,
	[Baslangic] [nvarchar](max) NULL,
	[Yil1] [nvarchar](max) NULL,
	[Yil2] [nvarchar](max) NULL,
	[Yil3] [nvarchar](max) NULL,
	[Yil4] [nvarchar](max) NULL,
	[Yil5] [nvarchar](max) NULL,
	[Yil1G] [nvarchar](max) NULL,
	[Yil2G] [nvarchar](max) NULL,
	[Yil3G] [nvarchar](max) NULL,
	[Yil4G] [nvarchar](max) NULL,
	[Yil5G] [nvarchar](max) NULL,
	[Kod] [nvarchar](max) NULL,
	[Baslik] [nvarchar](max) NULL,
	[Hedef_Id] [int] NULL,
	[SiraNo] [int] NOT NULL,
	[Izleme] [nvarchar](max) NULL,
	[Rapor] [nvarchar](max) NULL,
	[SorumluBirim] [nvarchar](max) NULL,
	[SorumluBirimId] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.burbis_11_Gostergeler] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[burbis_11_Hedefler]    Script Date: 15.11.2021 14:33:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[burbis_11_Hedefler](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Kod] [nvarchar](max) NULL,
	[Baslik] [nvarchar](max) NULL,
	[Amac_Id] [int] NULL,
	[SiraNo] [int] NOT NULL,
 CONSTRAINT [PK_dbo.burbis_11_Hedefler] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[burbis_11_Kurumlar]    Script Date: 15.11.2021 14:33:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[burbis_11_Kurumlar](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[KurumKodu] [int] NOT NULL,
	[Adi] [nvarchar](max) NULL,
	[Turu] [int] NOT NULL,
	[AktifPlanId] [int] NULL,
	[AktifYil] [int] NOT NULL,
	[FaaliyetGirisAcik] [bit] NOT NULL,
	[FaaliyetDurumGirisAcik] [bit] NOT NULL,
	[GostergeGirisAcik] [bit] NOT NULL,
	[Mesaj] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.burbis_11_Kurumlar] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[burbis_11_Plans]    Script Date: 15.11.2021 14:33:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[burbis_11_Plans](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Baslangic] [int] NOT NULL,
	[Bitis] [int] NOT NULL,
	[KurumId] [int] NULL,
 CONSTRAINT [PK_dbo.burbis_11_Plans] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[burbis_11_Stratejiler]    Script Date: 15.11.2021 14:33:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[burbis_11_Stratejiler](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Kod] [nvarchar](max) NULL,
	[Baslik] [nvarchar](max) NULL,
	[Hedef_Id] [int] NULL,
	[SiraNo] [int] NOT NULL,
 CONSTRAINT [PK_dbo.burbis_11_Stratejiler] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[burbis_11_Amaclar] ON 
GO
INSERT [dbo].[burbis_11_Amaclar] ([Id], [StratejikPlanId], [Kod], [Baslik], [SiraNo]) VALUES (1, 1, N'1', N'Bütün öğrencilerimize, medeniyetimizin ve insanlığın ortak değerleri ile çağın gereklerine uygun bilgi, beceri, tutum ve davranışların kazandırılması sağlanacaktır', 1)
GO
INSERT [dbo].[burbis_11_Amaclar] ([Id], [StratejikPlanId], [Kod], [Baslik], [SiraNo]) VALUES (2, 1, N'2', N'Çağdaş normlara uygun, etkili, verimli yönetim ve organizasyon yapısı ve süreçleri hâkim kılınacaktır', 2)
GO
INSERT [dbo].[burbis_11_Amaclar] ([Id], [StratejikPlanId], [Kod], [Baslik], [SiraNo]) VALUES (6, 1, N'3', N'Okul öncesi eğitim ve temel eğitimde öğrencilerimizin bilişsel, duygusal ve fiziksel olarak çok boyutlu gelişimleri sağlanacaktır', 3)
GO
INSERT [dbo].[burbis_11_Amaclar] ([Id], [StratejikPlanId], [Kod], [Baslik], [SiraNo]) VALUES (9, 7, N'1', N'AMACIM 2', 1)
GO
INSERT [dbo].[burbis_11_Amaclar] ([Id], [StratejikPlanId], [Kod], [Baslik], [SiraNo]) VALUES (10, 7, N'2', N'AMACIM 3', 2)
GO
INSERT [dbo].[burbis_11_Amaclar] ([Id], [StratejikPlanId], [Kod], [Baslik], [SiraNo]) VALUES (11, 7, N'3', N'sddsds', 3)
GO
SET IDENTITY_INSERT [dbo].[burbis_11_Amaclar] OFF
GO
SET IDENTITY_INSERT [dbo].[burbis_11_Birimler] ON 
GO
INSERT [dbo].[burbis_11_Birimler] ([Id], [BurbisId], [Kodu], [Baslik], [KurumId]) VALUES (55, 1, N'1', N'ARGE', 2)
GO
INSERT [dbo].[burbis_11_Birimler] ([Id], [BurbisId], [Kodu], [Baslik], [KurumId]) VALUES (56, 2, NULL, N'Arşiv', 2)
GO
INSERT [dbo].[burbis_11_Birimler] ([Id], [BurbisId], [Kodu], [Baslik], [KurumId]) VALUES (57, 3, NULL, N'Avukatlar', 2)
GO
INSERT [dbo].[burbis_11_Birimler] ([Id], [BurbisId], [Kodu], [Baslik], [KurumId]) VALUES (58, 4, NULL, N'Basın ve Halkla İlişkiler', 2)
GO
INSERT [dbo].[burbis_11_Birimler] ([Id], [BurbisId], [Kodu], [Baslik], [KurumId]) VALUES (59, 5, NULL, N'Bilgi İşlem ve Eğitim Teknolojileri', 2)
GO
INSERT [dbo].[burbis_11_Birimler] ([Id], [BurbisId], [Kodu], [Baslik], [KurumId]) VALUES (60, 7, NULL, N'Danışma ve Güvenlik', 2)
GO
INSERT [dbo].[burbis_11_Birimler] ([Id], [BurbisId], [Kodu], [Baslik], [KurumId]) VALUES (61, 8, NULL, N'Denklik', 2)
GO
INSERT [dbo].[burbis_11_Birimler] ([Id], [BurbisId], [Kodu], [Baslik], [KurumId]) VALUES (62, 9, NULL, N'DEPO (Destek Hizmetleri)', 2)
GO
INSERT [dbo].[burbis_11_Birimler] ([Id], [BurbisId], [Kodu], [Baslik], [KurumId]) VALUES (63, 10, NULL, N'Destek Hizmetleri (Mutemetlik)', 2)
GO
INSERT [dbo].[burbis_11_Birimler] ([Id], [BurbisId], [Kodu], [Baslik], [KurumId]) VALUES (64, 11, NULL, N'Destek Hizmetleri(Bütçe-Donatım-Taşınır)', 2)
GO
INSERT [dbo].[burbis_11_Birimler] ([Id], [BurbisId], [Kodu], [Baslik], [KurumId]) VALUES (65, 12, NULL, N'Din Öğretimi', 2)
GO
INSERT [dbo].[burbis_11_Birimler] ([Id], [BurbisId], [Kodu], [Baslik], [KurumId]) VALUES (66, 15, NULL, N'Evrak Kayıt', 2)
GO
INSERT [dbo].[burbis_11_Birimler] ([Id], [BurbisId], [Kodu], [Baslik], [KurumId]) VALUES (67, 16, NULL, N'Genel', 2)
GO
INSERT [dbo].[burbis_11_Birimler] ([Id], [BurbisId], [Kodu], [Baslik], [KurumId]) VALUES (68, 17, NULL, N'Hayat Boyu Öğrenme', 2)
GO
INSERT [dbo].[burbis_11_Birimler] ([Id], [BurbisId], [Kodu], [Baslik], [KurumId]) VALUES (69, 18, NULL, N'Hukuk Hizmetleri', 2)
GO
INSERT [dbo].[burbis_11_Birimler] ([Id], [BurbisId], [Kodu], [Baslik], [KurumId]) VALUES (70, 19, NULL, N'İl Enerji Yönetimi', 2)
GO
INSERT [dbo].[burbis_11_Birimler] ([Id], [BurbisId], [Kodu], [Baslik], [KurumId]) VALUES (71, 20, NULL, N'İnceleme ve Rehberlik', 2)
GO
INSERT [dbo].[burbis_11_Birimler] ([Id], [BurbisId], [Kodu], [Baslik], [KurumId]) VALUES (72, 21, NULL, N'İnşaat Emlak Hizmetleri(Emlak Büro)', 2)
GO
INSERT [dbo].[burbis_11_Birimler] ([Id], [BurbisId], [Kodu], [Baslik], [KurumId]) VALUES (73, 22, NULL, N'İnşaat Emlak Hizmetleri(İnşaat Büro)', 2)
GO
INSERT [dbo].[burbis_11_Birimler] ([Id], [BurbisId], [Kodu], [Baslik], [KurumId]) VALUES (74, 23, NULL, N'İnşaat Emlak Hizmetleri(Teknik Büro)', 2)
GO
INSERT [dbo].[burbis_11_Birimler] ([Id], [BurbisId], [Kodu], [Baslik], [KurumId]) VALUES (75, 24, NULL, N'İş Güvenliği', 2)
GO
INSERT [dbo].[burbis_11_Birimler] ([Id], [BurbisId], [Kodu], [Baslik], [KurumId]) VALUES (76, 25, NULL, N'Kat Görevlisi', 2)
GO
INSERT [dbo].[burbis_11_Birimler] ([Id], [BurbisId], [Kodu], [Baslik], [KurumId]) VALUES (77, 26, NULL, N'Mesleki ve Teknik Eğitim', 2)
GO
INSERT [dbo].[burbis_11_Birimler] ([Id], [BurbisId], [Kodu], [Baslik], [KurumId]) VALUES (78, 28, NULL, N'Orta Öğretim', 2)
GO
INSERT [dbo].[burbis_11_Birimler] ([Id], [BurbisId], [Kodu], [Baslik], [KurumId]) VALUES (79, 29, NULL, N'Öğretmen Atama', 2)
GO
INSERT [dbo].[burbis_11_Birimler] ([Id], [BurbisId], [Kodu], [Baslik], [KurumId]) VALUES (80, 30, NULL, N'Öğretmen Yetiştirme (Aday Performans)', 2)
GO
INSERT [dbo].[burbis_11_Birimler] ([Id], [BurbisId], [Kodu], [Baslik], [KurumId]) VALUES (81, 31, NULL, N'Öğretmen Yetiştirme (Hizmetiçi)', 2)
GO
INSERT [dbo].[burbis_11_Birimler] ([Id], [BurbisId], [Kodu], [Baslik], [KurumId]) VALUES (82, 33, NULL, N'Özel Büro', 2)
GO
INSERT [dbo].[burbis_11_Birimler] ([Id], [BurbisId], [Kodu], [Baslik], [KurumId]) VALUES (83, 34, NULL, N'Özel Eğitim ve Rehberlik', 2)
GO
INSERT [dbo].[burbis_11_Birimler] ([Id], [BurbisId], [Kodu], [Baslik], [KurumId]) VALUES (84, 35, NULL, N'Özel Kalem', 2)
GO
INSERT [dbo].[burbis_11_Birimler] ([Id], [BurbisId], [Kodu], [Baslik], [KurumId]) VALUES (85, 38, NULL, N'Özel Öğretim', 2)
GO
INSERT [dbo].[burbis_11_Birimler] ([Id], [BurbisId], [Kodu], [Baslik], [KurumId]) VALUES (86, 39, NULL, N'Özlük-Terfi-Emeklilik', 2)
GO
INSERT [dbo].[burbis_11_Birimler] ([Id], [BurbisId], [Kodu], [Baslik], [KurumId]) VALUES (87, 40, NULL, N'Pasaport', 2)
GO
INSERT [dbo].[burbis_11_Birimler] ([Id], [BurbisId], [Kodu], [Baslik], [KurumId]) VALUES (88, 41, NULL, N'Personel Atama', 2)
GO
INSERT [dbo].[burbis_11_Birimler] ([Id], [BurbisId], [Kodu], [Baslik], [KurumId]) VALUES (89, 43, NULL, N'Santral', 2)
GO
INSERT [dbo].[burbis_11_Birimler] ([Id], [BurbisId], [Kodu], [Baslik], [KurumId]) VALUES (90, 44, NULL, N'Sınav Hizmetleri', 2)
GO
INSERT [dbo].[burbis_11_Birimler] ([Id], [BurbisId], [Kodu], [Baslik], [KurumId]) VALUES (91, 45, NULL, N'Sivil Savunma', 2)
GO
INSERT [dbo].[burbis_11_Birimler] ([Id], [BurbisId], [Kodu], [Baslik], [KurumId]) VALUES (92, 46, NULL, N'Strateji Geliştirme', 2)
GO
INSERT [dbo].[burbis_11_Birimler] ([Id], [BurbisId], [Kodu], [Baslik], [KurumId]) VALUES (93, 47, NULL, N'Şoförler', 2)
GO
INSERT [dbo].[burbis_11_Birimler] ([Id], [BurbisId], [Kodu], [Baslik], [KurumId]) VALUES (94, 48, NULL, N'Taşımalı Eğitim', 2)
GO
INSERT [dbo].[burbis_11_Birimler] ([Id], [BurbisId], [Kodu], [Baslik], [KurumId]) VALUES (95, 49, NULL, N'Teknik Büro (Destek Hizmetleri)', 2)
GO
INSERT [dbo].[burbis_11_Birimler] ([Id], [BurbisId], [Kodu], [Baslik], [KurumId]) VALUES (96, 50, NULL, N'Temel Eğitim(Anaokulu-İlkokul)', 2)
GO
INSERT [dbo].[burbis_11_Birimler] ([Id], [BurbisId], [Kodu], [Baslik], [KurumId]) VALUES (97, 51, NULL, N'Temel Eğitim(Ortaokul)', 2)
GO
INSERT [dbo].[burbis_11_Birimler] ([Id], [BurbisId], [Kodu], [Baslik], [KurumId]) VALUES (98, 52, NULL, N'Tesis Müdürlüğü', 2)
GO
INSERT [dbo].[burbis_11_Birimler] ([Id], [BurbisId], [Kodu], [Baslik], [KurumId]) VALUES (99, 54, NULL, N'Yemekhane', 2)
GO
INSERT [dbo].[burbis_11_Birimler] ([Id], [BurbisId], [Kodu], [Baslik], [KurumId]) VALUES (100, 55, NULL, N'Yönetici Atama', 2)
GO
SET IDENTITY_INSERT [dbo].[burbis_11_Birimler] OFF
GO
SET IDENTITY_INSERT [dbo].[burbis_11_Eylemler] ON 
GO
INSERT [dbo].[burbis_11_Eylemler] ([Id], [Birim], [StratejiId], [Kod], [Baslik], [SiraNo]) VALUES (1, N'55,56,57,58,59,60,64', 33, N'1.1.1.1', N'Öğrencilerin akademik başarısı, ilgi ve
yetenekleri doğrultusunda yönlendirme çalışmalarının yapılması için gerekli
tedbirler alınacak, öğrenci ve velilere bu konuda rehberlik yapılacaktır.', 1)
GO
INSERT [dbo].[burbis_11_Eylemler] ([Id], [Birim], [StratejiId], [Kod], [Baslik], [SiraNo]) VALUES (2, NULL, 34, N'1.1.2.1', N'Her düzey eğitim kademesinde gerçekleştirilen
sosyal, sanatsal ve sportif faaliyetlerin sayısı artırılacaktır.', 1)
GO
INSERT [dbo].[burbis_11_Eylemler] ([Id], [Birim], [StratejiId], [Kod], [Baslik], [SiraNo]) VALUES (3, NULL, 34, N'1.1.2.2', N'Bütün eğitim kademelerinde bilimsel, kültürel,
sanatsal, sportif ve toplum hizmeti alanlarında etkinliklere katılım oranı
artırılacaktır. ', 2)
GO
INSERT [dbo].[burbis_11_Eylemler] ([Id], [Birim], [StratejiId], [Kod], [Baslik], [SiraNo]) VALUES (4, NULL, 35, N'1.1.3.1', N'Her düzey eğitim kademesinde gerçekleştirilen
sosyal, sanatsal ve sportif faaliyetlerin sayısı artırılacaktır.', 1)
GO
INSERT [dbo].[burbis_11_Eylemler] ([Id], [Birim], [StratejiId], [Kod], [Baslik], [SiraNo]) VALUES (5, NULL, 43, N'1.2.1.1', N'null', 1)
GO
INSERT [dbo].[burbis_11_Eylemler] ([Id], [Birim], [StratejiId], [Kod], [Baslik], [SiraNo]) VALUES (6, N'57,58', 33, N'1.1.1.2', N'Öğrencilerin başarısını artırmak, sosyal,
sportif ve kültürel faaliyetlerini gerçekleştirmeleri için yerel yönetimler ve
ilgili paydaşlarla işbirliği çalışmaları yapılacaktır.', 2)
GO
INSERT [dbo].[burbis_11_Eylemler] ([Id], [Birim], [StratejiId], [Kod], [Baslik], [SiraNo]) VALUES (7, NULL, 33, N'1.1.1.3', N'Erken çocukluk eğitiminden başlayarak üst
öğrenim kademelerinde de devam edecek şekilde çocukların tüm gelişim
alanlarının izlenmesi, değerlendirilmesi ve iyileştirilmesine yönelik
Bakanlığımız tarafından kurulacak e-portfolyo, sistemi uygulanacaktır.', 3)
GO
INSERT [dbo].[burbis_11_Eylemler] ([Id], [Birim], [StratejiId], [Kod], [Baslik], [SiraNo]) VALUES (8, NULL, 33, N'1.1.1.4', N'Merkezi sınav sonuçlarının analizleri
yapılacaktır.', 4)
GO
INSERT [dbo].[burbis_11_Eylemler] ([Id], [Birim], [StratejiId], [Kod], [Baslik], [SiraNo]) VALUES (9, NULL, 33, N'1.1.1.5', N'Hedeflenen öğrenci nüfusunun (okul türü, bölge,
cinsiyet, sosyo-ekonomik statü) yeterlilik seviyeleri belirlenecek, yıllar
içindeki değişimlerini takip etmek üzere veri toplanacaktır.', 5)
GO
INSERT [dbo].[burbis_11_Eylemler] ([Id], [Birim], [StratejiId], [Kod], [Baslik], [SiraNo]) VALUES (10, NULL, 33, N'1.1.1.6', N'İl genelinde Destek eğitimleri, destekleme ve
yetiştirme kursları, öğrenme güçlüğü çeken öğrencilere yönelik faaliyetler
gerçekleştirilecektir.', 6)
GO
INSERT [dbo].[burbis_11_Eylemler] ([Id], [Birim], [StratejiId], [Kod], [Baslik], [SiraNo]) VALUES (11, NULL, 33, N'1.1.1.7', N'İlimizde Ölçme-değerlendirme merkezlerinin etkin
ve verimli kullanılması, yerel imkânlardan yararlanılması, okul-ilçe-il
düzeyinde sınavlara yönelik ortak sınav, tarama testleri, rehberlik
faaliyetleri gibi etkinlikler yürütülecektir.', 7)
GO
INSERT [dbo].[burbis_11_Eylemler] ([Id], [Birim], [StratejiId], [Kod], [Baslik], [SiraNo]) VALUES (12, N'56', 47, N'1.1.1.1', N'ddfgdfgdfgdfg', 1)
GO
INSERT [dbo].[burbis_11_Eylemler] ([Id], [Birim], [StratejiId], [Kod], [Baslik], [SiraNo]) VALUES (13, N'55,57', 47, N'1.1.1.2', NULL, 2)
GO
INSERT [dbo].[burbis_11_Eylemler] ([Id], [Birim], [StratejiId], [Kod], [Baslik], [SiraNo]) VALUES (14, N'56', 47, N'1.1.1.3', NULL, 3)
GO
INSERT [dbo].[burbis_11_Eylemler] ([Id], [Birim], [StratejiId], [Kod], [Baslik], [SiraNo]) VALUES (15, N'55', 44, N'1.2.2.1', N'asdasdasdasdasdasd', 1)
GO
SET IDENTITY_INSERT [dbo].[burbis_11_Eylemler] OFF
GO
SET IDENTITY_INSERT [dbo].[burbis_11_Faaliyetler] ON 
GO
INSERT [dbo].[burbis_11_Faaliyetler] ([Id], [EylemId], [Baslama], [Bitis], [Gerceklesme], [Sonuc], [Durum], [Birim], [Kod], [Baslik], [SiraNo], [BirimAdi], [Yil], [Onay1], [Onay2]) VALUES (2, 6, CAST(N'2021-10-06T00:00:00.000' AS DateTime), CAST(N'2021-10-29T00:00:00.000' AS DateTime), N'99999', N'9999', N'Devam Ediyor', 55, NULL, N'Faaliyet 1', 0, NULL, 0, 0, 0)
GO
INSERT [dbo].[burbis_11_Faaliyetler] ([Id], [EylemId], [Baslama], [Bitis], [Gerceklesme], [Sonuc], [Durum], [Birim], [Kod], [Baslik], [SiraNo], [BirimAdi], [Yil], [Onay1], [Onay2]) VALUES (3, 7, CAST(N'2021-10-14T00:00:00.000' AS DateTime), CAST(N'2021-10-14T00:00:00.000' AS DateTime), N'ewrwerwerwerwer', N'werwerwer', N'Devam Ediyor', 55, NULL, N'faaliyet 2', 0, NULL, 0, 0, 0)
GO
INSERT [dbo].[burbis_11_Faaliyetler] ([Id], [EylemId], [Baslama], [Bitis], [Gerceklesme], [Sonuc], [Durum], [Birim], [Kod], [Baslik], [SiraNo], [BirimAdi], [Yil], [Onay1], [Onay2]) VALUES (4, 8, CAST(N'2021-10-07T00:00:00.000' AS DateTime), NULL, NULL, NULL, N'İptal Edildi', 55, NULL, N'asdasdasdasd', 0, NULL, 0, 0, 0)
GO
INSERT [dbo].[burbis_11_Faaliyetler] ([Id], [EylemId], [Baslama], [Bitis], [Gerceklesme], [Sonuc], [Durum], [Birim], [Kod], [Baslik], [SiraNo], [BirimAdi], [Yil], [Onay1], [Onay2]) VALUES (7, 8, NULL, NULL, NULL, NULL, NULL, 55, NULL, N'tttttttttttttttttttttttt', 0, NULL, 0, 0, 0)
GO
INSERT [dbo].[burbis_11_Faaliyetler] ([Id], [EylemId], [Baslama], [Bitis], [Gerceklesme], [Sonuc], [Durum], [Birim], [Kod], [Baslik], [SiraNo], [BirimAdi], [Yil], [Onay1], [Onay2]) VALUES (8, 1, NULL, NULL, NULL, NULL, NULL, 55, NULL, N'lllllllllllllllllllllll', 0, NULL, 0, 0, 0)
GO
SET IDENTITY_INSERT [dbo].[burbis_11_Faaliyetler] OFF
GO
SET IDENTITY_INSERT [dbo].[burbis_11_GostergeGirisleri] ON 
GO
INSERT [dbo].[burbis_11_GostergeGirisleri] ([Id], [GostergeId], [Yil], [BirimId], [Onay], [Deger]) VALUES (1, 3, 2, 55, 0, N'5')
GO
INSERT [dbo].[burbis_11_GostergeGirisleri] ([Id], [GostergeId], [Yil], [BirimId], [Onay], [Deger]) VALUES (2, 13, 2, 55, 0, N'6')
GO
INSERT [dbo].[burbis_11_GostergeGirisleri] ([Id], [GostergeId], [Yil], [BirimId], [Onay], [Deger]) VALUES (3, 31, 3, 57, 0, N'56')
GO
SET IDENTITY_INSERT [dbo].[burbis_11_GostergeGirisleri] OFF
GO
SET IDENTITY_INSERT [dbo].[burbis_11_Gostergeler] ON 
GO
INSERT [dbo].[burbis_11_Gostergeler] ([Id], [HedefeEtkisi], [Baslangic], [Yil1], [Yil2], [Yil3], [Yil4], [Yil5], [Yil1G], [Yil2G], [Yil3G], [Yil4G], [Yil5G], [Kod], [Baslik], [Hedef_Id], [SiraNo], [Izleme], [Rapor], [SorumluBirim], [SorumluBirimId]) VALUES (3, N'20', N'55,42', N'70', N'78', N'88', N'95', N'100', NULL, NULL, NULL, NULL, NULL, N'1.1.1.1', N'Bir eğitim ve öğretim döneminde bilimsel, kültürel, sanatsal ve sportif alanlarda en az bir faaliyete katılan öğrenci oranı (%) - İlkokul', 1, 1, N'6 Ay', N'1 Yıl', N'ARGEArşiv', N'55,56')
GO
INSERT [dbo].[burbis_11_Gostergeler] ([Id], [HedefeEtkisi], [Baslangic], [Yil1], [Yil2], [Yil3], [Yil4], [Yil5], [Yil1G], [Yil2G], [Yil3G], [Yil4G], [Yil5G], [Kod], [Baslik], [Hedef_Id], [SiraNo], [Izleme], [Rapor], [SorumluBirim], [SorumluBirimId]) VALUES (12, N'20', N'51', N'60', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'1.1.1.2', N'Bir eğitim ve öğretim döneminde bilimsel, kültürel, sanatsal ve sportif alanlarda en az bir faaliyete katılan öğrenci oranı (%) -Ortaokul', 1, 2, N'6 Ay', N'6 Ay', N'ARGE', N'55')
GO
INSERT [dbo].[burbis_11_Gostergeler] ([Id], [HedefeEtkisi], [Baslangic], [Yil1], [Yil2], [Yil3], [Yil4], [Yil5], [Yil1G], [Yil2G], [Yil3G], [Yil4G], [Yil5G], [Kod], [Baslik], [Hedef_Id], [SiraNo], [Izleme], [Rapor], [SorumluBirim], [SorumluBirimId]) VALUES (13, N'20', N'65', N'70', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'1.1.1.3', N'Bir eğitim ve öğretim döneminde bilimsel, kültürel, sanatsal ve sportif alanlarda en az bir faaliyete katılan öğrenci oranı (%) - Lise', 1, 3, N'6 Ay', N'6 Ay', N'', N'')
GO
INSERT [dbo].[burbis_11_Gostergeler] ([Id], [HedefeEtkisi], [Baslangic], [Yil1], [Yil2], [Yil3], [Yil4], [Yil5], [Yil1G], [Yil2G], [Yil3G], [Yil4G], [Yil5G], [Kod], [Baslik], [Hedef_Id], [SiraNo], [Izleme], [Rapor], [SorumluBirim], [SorumluBirimId]) VALUES (18, N'60', N'74', N'75', N'76', N'77', N'78', N'80', NULL, NULL, NULL, NULL, NULL, N'1.2.1', N'Yabancı dil dersi yılsonu puan ortalaması', 5, 1, N'6 Ay', N'6 Ay', N'', N'')
GO
INSERT [dbo].[burbis_11_Gostergeler] ([Id], [HedefeEtkisi], [Baslangic], [Yil1], [Yil2], [Yil3], [Yil4], [Yil5], [Yil1G], [Yil2G], [Yil3G], [Yil4G], [Yil5G], [Kod], [Baslik], [Hedef_Id], [SiraNo], [Izleme], [Rapor], [SorumluBirim], [SorumluBirimId]) VALUES (19, N'40', N'5', N'50', N'200', N'400', N'800', N'1000', NULL, NULL, NULL, NULL, NULL, N'1.2.2', N'Yabancı Dil Mesleki Gelişim Programlarına katılan yabancı dil öğretmeni sayısı', 5, 2, N'6 Ay', N'6 Ay', N'', N'')
GO
INSERT [dbo].[burbis_11_Gostergeler] ([Id], [HedefeEtkisi], [Baslangic], [Yil1], [Yil2], [Yil3], [Yil4], [Yil5], [Yil1G], [Yil2G], [Yil3G], [Yil4G], [Yil5G], [Kod], [Baslik], [Hedef_Id], [SiraNo], [Izleme], [Rapor], [SorumluBirim], [SorumluBirimId]) VALUES (21, N'50', N'51478', N'73254', N'95647', N'102000', N'125478', N'155236', NULL, N'2', N'8', NULL, NULL, N'1.3.1', N'EBA Ders Portali aylık ortalama tekil ziyaretçi sayısı', 9, 1, N'6 Ay', N'6 Ay', N'', N'')
GO
INSERT [dbo].[burbis_11_Gostergeler] ([Id], [HedefeEtkisi], [Baslangic], [Yil1], [Yil2], [Yil3], [Yil4], [Yil5], [Yil1G], [Yil2G], [Yil3G], [Yil4G], [Yil5G], [Kod], [Baslik], [Hedef_Id], [SiraNo], [Izleme], [Rapor], [SorumluBirim], [SorumluBirimId]) VALUES (22, N'25', N'520', N'600', N'675', N'750', N'825', N'900', NULL, N'2', N'9', NULL, NULL, N' 1.3.2.1', N' EBA Ders Portali kullanıcı başına aylık ortalama sistemde kalma süresi (dk.) - Öğretmen', 9, 2, N'6 Ay', N'6 Ay', N'', N'')
GO
INSERT [dbo].[burbis_11_Gostergeler] ([Id], [HedefeEtkisi], [Baslangic], [Yil1], [Yil2], [Yil3], [Yil4], [Yil5], [Yil1G], [Yil2G], [Yil3G], [Yil4G], [Yil5G], [Kod], [Baslik], [Hedef_Id], [SiraNo], [Izleme], [Rapor], [SorumluBirim], [SorumluBirimId]) VALUES (23, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'null', NULL, 1, NULL, NULL, N'(BİRİM SEÇİNİZ)', NULL)
GO
INSERT [dbo].[burbis_11_Gostergeler] ([Id], [HedefeEtkisi], [Baslangic], [Yil1], [Yil2], [Yil3], [Yil4], [Yil5], [Yil1G], [Yil2G], [Yil3G], [Yil4G], [Yil5G], [Kod], [Baslik], [Hedef_Id], [SiraNo], [Izleme], [Rapor], [SorumluBirim], [SorumluBirimId]) VALUES (24, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'null', NULL, 2, NULL, NULL, N'(BİRİM SEÇİNİZ)', NULL)
GO
INSERT [dbo].[burbis_11_Gostergeler] ([Id], [HedefeEtkisi], [Baslangic], [Yil1], [Yil2], [Yil3], [Yil4], [Yil5], [Yil1G], [Yil2G], [Yil3G], [Yil4G], [Yil5G], [Kod], [Baslik], [Hedef_Id], [SiraNo], [Izleme], [Rapor], [SorumluBirim], [SorumluBirimId]) VALUES (25, N'40', N'15,55', N'25', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'1.1.2.1', N'Öğrenci başına okunan kitap sayısı -  İlkokul', 1, 4, N'6 Ay', N'6 Ay', N'', N'')
GO
INSERT [dbo].[burbis_11_Gostergeler] ([Id], [HedefeEtkisi], [Baslangic], [Yil1], [Yil2], [Yil3], [Yil4], [Yil5], [Yil1G], [Yil2G], [Yil3G], [Yil4G], [Yil5G], [Kod], [Baslik], [Hedef_Id], [SiraNo], [Izleme], [Rapor], [SorumluBirim], [SorumluBirimId]) VALUES (26, N'25', N'6835', N'7500', N'8000', N'8400', N'8750', N'9000', NULL, N'2', N'10', NULL, NULL, N' 1.3.2.1', N'EBA Ders Portali kullanıcı başına aylık ortalama sistemde kalma süresi (dk.) - Öğrenci', 9, 3, N'6 Ay', N'6 Ay', N'', N'')
GO
INSERT [dbo].[burbis_11_Gostergeler] ([Id], [HedefeEtkisi], [Baslangic], [Yil1], [Yil2], [Yil3], [Yil4], [Yil5], [Yil1G], [Yil2G], [Yil3G], [Yil4G], [Yil5G], [Kod], [Baslik], [Hedef_Id], [SiraNo], [Izleme], [Rapor], [SorumluBirim], [SorumluBirimId]) VALUES (27, N'40', N'10,06', N'11', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'1.1.2.2', N'Öğrenci başına okunan kitap sayısı - Ortaokul', 1, 5, N'6 Ay', N'6 Ay', N'', N'')
GO
INSERT [dbo].[burbis_11_Gostergeler] ([Id], [HedefeEtkisi], [Baslangic], [Yil1], [Yil2], [Yil3], [Yil4], [Yil5], [Yil1G], [Yil2G], [Yil3G], [Yil4G], [Yil5G], [Kod], [Baslik], [Hedef_Id], [SiraNo], [Izleme], [Rapor], [SorumluBirim], [SorumluBirimId]) VALUES (28, N'40', N'6', N'7', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'1.1.2.3', N'Öğrenci başına okunan kitap sayısı - Lise', 1, 6, N'6 Ay', N'6 Ay', N'', N'')
GO
INSERT [dbo].[burbis_11_Gostergeler] ([Id], [HedefeEtkisi], [Baslangic], [Yil1], [Yil2], [Yil3], [Yil4], [Yil5], [Yil1G], [Yil2G], [Yil3G], [Yil4G], [Yil5G], [Kod], [Baslik], [Hedef_Id], [SiraNo], [Izleme], [Rapor], [SorumluBirim], [SorumluBirimId]) VALUES (29, N'40', N'12', N'11', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'1.1.3', N'Ortaöğretime merkezi sınavla yerleşen öğrenci oranı (%)', 1, 7, N'6 Ay', N'6 Ay', N'', N'')
GO
INSERT [dbo].[burbis_11_Gostergeler] ([Id], [HedefeEtkisi], [Baslangic], [Yil1], [Yil2], [Yil3], [Yil4], [Yil5], [Yil1G], [Yil2G], [Yil3G], [Yil4G], [Yil5G], [Kod], [Baslik], [Hedef_Id], [SiraNo], [Izleme], [Rapor], [SorumluBirim], [SorumluBirimId]) VALUES (31, N'10', N'24', N'25', N'26', N'27', N'28', N'29', NULL, NULL, NULL, NULL, NULL, NULL, N'Deneme gösterge', 3, 1, N'6 Ay', N'6 Ay', N'ARGEArşivAvukatlar', N'55,56,57')
GO
INSERT [dbo].[burbis_11_Gostergeler] ([Id], [HedefeEtkisi], [Baslangic], [Yil1], [Yil2], [Yil3], [Yil4], [Yil5], [Yil1G], [Yil2G], [Yil3G], [Yil4G], [Yil5G], [Kod], [Baslik], [Hedef_Id], [SiraNo], [Izleme], [Rapor], [SorumluBirim], [SorumluBirimId]) VALUES (32, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'null', 11, 1, NULL, N'6 Ay', N'ARGE', N'55')
GO
INSERT [dbo].[burbis_11_Gostergeler] ([Id], [HedefeEtkisi], [Baslangic], [Yil1], [Yil2], [Yil3], [Yil4], [Yil5], [Yil1G], [Yil2G], [Yil3G], [Yil4G], [Yil5G], [Kod], [Baslik], [Hedef_Id], [SiraNo], [Izleme], [Rapor], [SorumluBirim], [SorumluBirimId]) VALUES (33, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'null', 11, 2, NULL, NULL, N'', N'')
GO
INSERT [dbo].[burbis_11_Gostergeler] ([Id], [HedefeEtkisi], [Baslangic], [Yil1], [Yil2], [Yil3], [Yil4], [Yil5], [Yil1G], [Yil2G], [Yil3G], [Yil4G], [Yil5G], [Kod], [Baslik], [Hedef_Id], [SiraNo], [Izleme], [Rapor], [SorumluBirim], [SorumluBirimId]) VALUES (34, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'j', 13, 1, NULL, NULL, N'ARGEArşiv', N'55,56')
GO
INSERT [dbo].[burbis_11_Gostergeler] ([Id], [HedefeEtkisi], [Baslangic], [Yil1], [Yil2], [Yil3], [Yil4], [Yil5], [Yil1G], [Yil2G], [Yil3G], [Yil4G], [Yil5G], [Kod], [Baslik], [Hedef_Id], [SiraNo], [Izleme], [Rapor], [SorumluBirim], [SorumluBirimId]) VALUES (35, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'hj', 13, 2, NULL, NULL, N'', N'')
GO
SET IDENTITY_INSERT [dbo].[burbis_11_Gostergeler] OFF
GO
SET IDENTITY_INSERT [dbo].[burbis_11_Hedefler] ON 
GO
INSERT [dbo].[burbis_11_Hedefler] ([Id], [Kod], [Baslik], [Amac_Id], [SiraNo]) VALUES (1, N'1.1', N'Tüm alanlarda ve eğitim kademelerinde, öğrencilerimizin her düzeydeki yeterliliklerinin belirlenmesi, izlenmesi ve desteklenmesi için kurulacak ölçme ve değerlendirme sistemine il düzeyinde işlerlik kazandırılacaktır.', 1, 1)
GO
INSERT [dbo].[burbis_11_Hedefler] ([Id], [Kod], [Baslik], [Amac_Id], [SiraNo]) VALUES (3, N'2.1', N'YENİ HEDEF', 2, 1)
GO
INSERT [dbo].[burbis_11_Hedefler] ([Id], [Kod], [Baslik], [Amac_Id], [SiraNo]) VALUES (4, N'2.2', N'YENİ HEDEF', 2, 2)
GO
INSERT [dbo].[burbis_11_Hedefler] ([Id], [Kod], [Baslik], [Amac_Id], [SiraNo]) VALUES (5, N'1.2', N'Öğrencilerin yaş, okul türü ve programlarına göre gereksinimlerini dikkate alan beceri temelli yabancı dil yeterlilikleri sistemine geçilmesine ilişkin etkin çalışmalar yürütülecektir.', 1, 2)
GO
INSERT [dbo].[burbis_11_Hedefler] ([Id], [Kod], [Baslik], [Amac_Id], [SiraNo]) VALUES (9, N'1.3', N'Öğrenme süreçlerini destekleyen dijital içerik ve beceri destekli dönüşüm ile ülkemizin her yerinde yaşayan öğrenci ve öğretmenlerimizin eşit öğrenme ve öğretme fırsatlarını yakalamaları ve öğrenmenin sınıf duvarlarını aşması sağlanacaktır.', 1, 3)
GO
INSERT [dbo].[burbis_11_Hedefler] ([Id], [Kod], [Baslik], [Amac_Id], [SiraNo]) VALUES (11, N'3.1', N'YENİ HEDEF', 6, 1)
GO
INSERT [dbo].[burbis_11_Hedefler] ([Id], [Kod], [Baslik], [Amac_Id], [SiraNo]) VALUES (13, N'1.1', N'YENİ HEDEF', 9, 1)
GO
SET IDENTITY_INSERT [dbo].[burbis_11_Hedefler] OFF
GO
SET IDENTITY_INSERT [dbo].[burbis_11_Kurumlar] ON 
GO
INSERT [dbo].[burbis_11_Kurumlar] ([Id], [KurumKodu], [Adi], [Turu], [AktifPlanId], [AktifYil], [FaaliyetGirisAcik], [FaaliyetDurumGirisAcik], [GostergeGirisAcik], [Mesaj]) VALUES (2, 123333, N'İL MİLLİ EĞİTİM MÜDÜRLÜĞÜ', 0, 1, 3, 0, 1, 1, N'<p>ppppppa</p>')
GO
INSERT [dbo].[burbis_11_Kurumlar] ([Id], [KurumKodu], [Adi], [Turu], [AktifPlanId], [AktifYil], [FaaliyetGirisAcik], [FaaliyetDurumGirisAcik], [GostergeGirisAcik], [Mesaj]) VALUES (3, 3434, N'DENEME KURUMU', 2, 2, 0, 1, 0, 1, N'<p>ĞĞĞĞĞĞ</p>')
GO
SET IDENTITY_INSERT [dbo].[burbis_11_Kurumlar] OFF
GO
SET IDENTITY_INSERT [dbo].[burbis_11_Plans] ON 
GO
INSERT [dbo].[burbis_11_Plans] ([Id], [Baslangic], [Bitis], [KurumId]) VALUES (1, 2019, 2023, 2)
GO
INSERT [dbo].[burbis_11_Plans] ([Id], [Baslangic], [Bitis], [KurumId]) VALUES (7, 2025, 2029, 2)
GO
SET IDENTITY_INSERT [dbo].[burbis_11_Plans] OFF
GO
SET IDENTITY_INSERT [dbo].[burbis_11_Stratejiler] ON 
GO
INSERT [dbo].[burbis_11_Stratejiler] ([Id], [Kod], [Baslik], [Hedef_Id], [SiraNo]) VALUES (33, N'1.1.1', N'Eğitim kalitesinin artırılması için ölçme ve değerlendirme yöntemleri etkinleştirilecek ve yeterlilik temelli ölçme değerlendirme yapılacaktır.', 1, 1)
GO
INSERT [dbo].[burbis_11_Stratejiler] ([Id], [Kod], [Baslik], [Hedef_Id], [SiraNo]) VALUES (34, N'1.1.2', N'Öğrencilerin bilimsel, kültürel, sanatsal, sportif ve toplum hizmeti alanlarında etkinliklere katılımı artırılacak ve izlenecektir.', 1, 2)
GO
INSERT [dbo].[burbis_11_Stratejiler] ([Id], [Kod], [Baslik], [Hedef_Id], [SiraNo]) VALUES (35, N'1.1.3', N'Kademeler arası geçiş sınavlarının öğrenciler üzerindeki baskısını azaltacak çalışmalar yapılacaktır.', 1, 3)
GO
INSERT [dbo].[burbis_11_Stratejiler] ([Id], [Kod], [Baslik], [Hedef_Id], [SiraNo]) VALUES (41, N'2.2.1', NULL, 4, 1)
GO
INSERT [dbo].[burbis_11_Stratejiler] ([Id], [Kod], [Baslik], [Hedef_Id], [SiraNo]) VALUES (42, N'2.2.2', NULL, 4, 2)
GO
INSERT [dbo].[burbis_11_Stratejiler] ([Id], [Kod], [Baslik], [Hedef_Id], [SiraNo]) VALUES (43, N'1.2.1', N'İl genelinde yabancı dil eğitimi, seviye ve okul türlerine göre uyarlanacaktır.', 5, 1)
GO
INSERT [dbo].[burbis_11_Stratejiler] ([Id], [Kod], [Baslik], [Hedef_Id], [SiraNo]) VALUES (44, N'1.2.2', N'Yeni kaynaklar ile öğrencilerin İngilizce konuşulan dünyayı deneyimlemesi ve Bakanlıkça geliştirilecek olan dijital içerikleri kullanmaları sağlanacaktır.', 5, 2)
GO
INSERT [dbo].[burbis_11_Stratejiler] ([Id], [Kod], [Baslik], [Hedef_Id], [SiraNo]) VALUES (45, N'1.2.3', N'Yabancı dil eğitiminde öğretmen nitelik ve yeterlilikleri yükseltilecektir.', 5, 3)
GO
INSERT [dbo].[burbis_11_Stratejiler] ([Id], [Kod], [Baslik], [Hedef_Id], [SiraNo]) VALUES (47, N'1.1.1', N' stratejimmm', 13, 1)
GO
INSERT [dbo].[burbis_11_Stratejiler] ([Id], [Kod], [Baslik], [Hedef_Id], [SiraNo]) VALUES (48, N'1.1.2', N' hjkhjkhjk', 13, 2)
GO
INSERT [dbo].[burbis_11_Stratejiler] ([Id], [Kod], [Baslik], [Hedef_Id], [SiraNo]) VALUES (49, N'1.1.3', N' hkhjkhjk', 13, 3)
GO
SET IDENTITY_INSERT [dbo].[burbis_11_Stratejiler] OFF
GO
ALTER TABLE [dbo].[burbis_11_Amaclar] ADD  DEFAULT ((0)) FOR [SiraNo]
GO
ALTER TABLE [dbo].[burbis_11_Faaliyetler] ADD  DEFAULT ((0)) FOR [Yil]
GO
ALTER TABLE [dbo].[burbis_11_Faaliyetler] ADD  DEFAULT ((0)) FOR [Onay1]
GO
ALTER TABLE [dbo].[burbis_11_Faaliyetler] ADD  DEFAULT ((0)) FOR [Onay2]
GO
ALTER TABLE [dbo].[burbis_11_Gostergeler] ADD  DEFAULT ((0)) FOR [SiraNo]
GO
ALTER TABLE [dbo].[burbis_11_Hedefler] ADD  DEFAULT ((0)) FOR [SiraNo]
GO
ALTER TABLE [dbo].[burbis_11_Kurumlar] ADD  DEFAULT ((0)) FOR [AktifYil]
GO
ALTER TABLE [dbo].[burbis_11_Kurumlar] ADD  DEFAULT ((0)) FOR [FaaliyetGirisAcik]
GO
ALTER TABLE [dbo].[burbis_11_Kurumlar] ADD  DEFAULT ((0)) FOR [FaaliyetDurumGirisAcik]
GO
ALTER TABLE [dbo].[burbis_11_Kurumlar] ADD  DEFAULT ((0)) FOR [GostergeGirisAcik]
GO
ALTER TABLE [dbo].[burbis_11_Plans] ADD  DEFAULT ((0)) FOR [KurumId]
GO
ALTER TABLE [dbo].[burbis_11_Stratejiler] ADD  DEFAULT ((0)) FOR [SiraNo]
GO
ALTER TABLE [dbo].[burbis_11_Amaclar]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Amaclar_dbo.Plans_StratejikPlanId] FOREIGN KEY([StratejikPlanId])
REFERENCES [dbo].[burbis_11_Plans] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[burbis_11_Amaclar] CHECK CONSTRAINT [FK_dbo.Amaclar_dbo.Plans_StratejikPlanId]
GO
ALTER TABLE [dbo].[burbis_11_Birimler]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Birimler_dbo.Kurumlar_KurumId] FOREIGN KEY([KurumId])
REFERENCES [dbo].[burbis_11_Kurumlar] ([Id])
GO
ALTER TABLE [dbo].[burbis_11_Birimler] CHECK CONSTRAINT [FK_dbo.Birimler_dbo.Kurumlar_KurumId]
GO
ALTER TABLE [dbo].[burbis_11_Eylemler]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Eylemler_dbo.Stratejiler_StratejiId] FOREIGN KEY([StratejiId])
REFERENCES [dbo].[burbis_11_Stratejiler] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[burbis_11_Eylemler] CHECK CONSTRAINT [FK_dbo.Eylemler_dbo.Stratejiler_StratejiId]
GO
ALTER TABLE [dbo].[burbis_11_Faaliyetler]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Faaliyetler_dbo.Eylemler_EylemId] FOREIGN KEY([EylemId])
REFERENCES [dbo].[burbis_11_Eylemler] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[burbis_11_Faaliyetler] CHECK CONSTRAINT [FK_dbo.Faaliyetler_dbo.Eylemler_EylemId]
GO
ALTER TABLE [dbo].[burbis_11_GostergeGirisleri]  WITH CHECK ADD  CONSTRAINT [FK_dbo.GostergeGirisleri_dbo.Birimler_BirimId] FOREIGN KEY([BirimId])
REFERENCES [dbo].[burbis_11_Birimler] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[burbis_11_GostergeGirisleri] CHECK CONSTRAINT [FK_dbo.GostergeGirisleri_dbo.Birimler_BirimId]
GO
ALTER TABLE [dbo].[burbis_11_GostergeGirisleri]  WITH CHECK ADD  CONSTRAINT [FK_dbo.GostergeGirisleri_dbo.Gostergeler_GostergeId] FOREIGN KEY([GostergeId])
REFERENCES [dbo].[burbis_11_Gostergeler] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[burbis_11_GostergeGirisleri] CHECK CONSTRAINT [FK_dbo.GostergeGirisleri_dbo.Gostergeler_GostergeId]
GO
ALTER TABLE [dbo].[burbis_11_Gostergeler]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Gostergeler_dbo.Hedefler_Hedef_Id] FOREIGN KEY([Hedef_Id])
REFERENCES [dbo].[burbis_11_Hedefler] ([Id])
GO
ALTER TABLE [dbo].[burbis_11_Gostergeler] CHECK CONSTRAINT [FK_dbo.Gostergeler_dbo.Hedefler_Hedef_Id]
GO
ALTER TABLE [dbo].[burbis_11_Hedefler]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Hedefler_dbo.Amaclar_Amac_Id] FOREIGN KEY([Amac_Id])
REFERENCES [dbo].[burbis_11_Amaclar] ([Id])
GO
ALTER TABLE [dbo].[burbis_11_Hedefler] CHECK CONSTRAINT [FK_dbo.Hedefler_dbo.Amaclar_Amac_Id]
GO
ALTER TABLE [dbo].[burbis_11_Plans]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Plans_dbo.Kurumlar_KurumId] FOREIGN KEY([KurumId])
REFERENCES [dbo].[burbis_11_Kurumlar] ([Id])
GO
ALTER TABLE [dbo].[burbis_11_Plans] CHECK CONSTRAINT [FK_dbo.Plans_dbo.Kurumlar_KurumId]
GO
ALTER TABLE [dbo].[burbis_11_Stratejiler]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Stratejiler_dbo.Hedefler_Hedef_Id] FOREIGN KEY([Hedef_Id])
REFERENCES [dbo].[burbis_11_Hedefler] ([Id])
GO
ALTER TABLE [dbo].[burbis_11_Stratejiler] CHECK CONSTRAINT [FK_dbo.Stratejiler_dbo.Hedefler_Hedef_Id]
GO
