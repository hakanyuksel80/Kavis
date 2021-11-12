
CREATE TABLE [dbo].[Kavis_Amaclar](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[StratejikPlanId] [int] NOT NULL,
	[Kod] [nvarchar](max) NULL,
	[Baslik] [nvarchar](max) NULL,
	[SiraNo] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Kavis_Amaclar] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Kavis_Birimler]    Script Date: 12.11.2021 14:35:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Kavis_Birimler](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BurbisId] [int] NOT NULL,
	[Kodu] [nvarchar](max) NULL,
	[Baslik] [nvarchar](max) NULL,
	[KurumId] [int] NULL,
 CONSTRAINT [PK_dbo.Kavis_Birimler] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Kavis_Eylemler]    Script Date: 12.11.2021 14:35:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Kavis_Eylemler](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Birim] [nvarchar](max) NULL,
	[StratejiId] [int] NOT NULL,
	[Kod] [nvarchar](max) NULL,
	[Baslik] [nvarchar](max) NULL,
	[SiraNo] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Kavis_Eylemler] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Kavis_Faaliyetler]    Script Date: 12.11.2021 14:35:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Kavis_Faaliyetler](
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
 CONSTRAINT [PK_dbo.Kavis_Faaliyetler] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Kavis_GostergeGirisleri]    Script Date: 12.11.2021 14:35:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Kavis_GostergeGirisleri](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[GostergeId] [int] NOT NULL,
	[Yil] [tinyint] NOT NULL,
	[BirimId] [int] NOT NULL,
	[Onay] [bit] NOT NULL,
	[Deger] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Kavis_GostergeGirisleri] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Kavis_Gostergeler]    Script Date: 12.11.2021 14:35:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Kavis_Gostergeler](
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
 CONSTRAINT [PK_dbo.Kavis_Gostergeler] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Kavis_Hedefler]    Script Date: 12.11.2021 14:35:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Kavis_Hedefler](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Kod] [nvarchar](max) NULL,
	[Baslik] [nvarchar](max) NULL,
	[Amac_Id] [int] NULL,
	[SiraNo] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Kavis_Hedefler] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Kavis_Kurumlar]    Script Date: 12.11.2021 14:35:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Kavis_Kurumlar](
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
 CONSTRAINT [PK_dbo.Kavis_Kurumlar] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Kavis_Plans]    Script Date: 12.11.2021 14:35:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Kavis_Plans](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Baslangic] [int] NOT NULL,
	[Bitis] [int] NOT NULL,
	[KurumId] [int] NULL,
 CONSTRAINT [PK_dbo.Kavis_Plans] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Kavis_Stratejiler]    Script Date: 12.11.2021 14:35:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Kavis_Stratejiler](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Kod] [nvarchar](max) NULL,
	[Baslik] [nvarchar](max) NULL,
	[Hedef_Id] [int] NULL,
	[SiraNo] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Kavis_Stratejiler] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

SET IDENTITY_INSERT [dbo].[Kavis_Amaclar] ON 
GO
INSERT [dbo].[Kavis_Amaclar] ([Id], [StratejikPlanId], [Kod], [Baslik], [SiraNo]) VALUES (1, 1, N'1', N'B�t�n ��rencilerimize, medeniyetimizin ve insanl���n ortak de�erleri ile �a��n gereklerine uygun bilgi, beceri, tutum ve davran��lar�n kazand�r�lmas� sa�lanacakt�r', 1)
GO
INSERT [dbo].[Kavis_Amaclar] ([Id], [StratejikPlanId], [Kod], [Baslik], [SiraNo]) VALUES (2, 1, N'2', N'�a�da� normlara uygun, etkili, verimli y�netim ve organizasyon yap�s� ve s�re�leri h�kim k�l�nacakt�r', 2)
GO
INSERT [dbo].[Kavis_Amaclar] ([Id], [StratejikPlanId], [Kod], [Baslik], [SiraNo]) VALUES (6, 1, N'3', N'Okul �ncesi e�itim ve temel e�itimde ��rencilerimizin bili�sel, duygusal ve fiziksel olarak �ok boyutlu geli�imleri sa�lanacakt�r', 3)
GO
INSERT [dbo].[Kavis_Amaclar] ([Id], [StratejikPlanId], [Kod], [Baslik], [SiraNo]) VALUES (9, 7, N'1', N'AMACIM 2', 1)
GO
INSERT [dbo].[Kavis_Amaclar] ([Id], [StratejikPlanId], [Kod], [Baslik], [SiraNo]) VALUES (10, 7, N'2', N'AMACIM 3', 2)
GO
INSERT [dbo].[Kavis_Amaclar] ([Id], [StratejikPlanId], [Kod], [Baslik], [SiraNo]) VALUES (11, 7, N'3', N'sddsds', 3)
GO
SET IDENTITY_INSERT [dbo].[Kavis_Amaclar] OFF
GO
SET IDENTITY_INSERT [dbo].[Kavis_Birimler] ON 
GO
INSERT [dbo].[Kavis_Birimler] ([Id], [BurbisId], [Kodu], [Baslik], [KurumId]) VALUES (55, 1, N'1', N'ARGE', 2)
GO
INSERT [dbo].[Kavis_Birimler] ([Id], [BurbisId], [Kodu], [Baslik], [KurumId]) VALUES (56, 2, NULL, N'Ar�iv', 2)
GO
INSERT [dbo].[Kavis_Birimler] ([Id], [BurbisId], [Kodu], [Baslik], [KurumId]) VALUES (57, 3, NULL, N'Avukatlar', 2)
GO
INSERT [dbo].[Kavis_Birimler] ([Id], [BurbisId], [Kodu], [Baslik], [KurumId]) VALUES (58, 4, NULL, N'Bas�n ve Halkla �li�kiler', 2)
GO
INSERT [dbo].[Kavis_Birimler] ([Id], [BurbisId], [Kodu], [Baslik], [KurumId]) VALUES (59, 5, NULL, N'Bilgi ��lem ve E�itim Teknolojileri', 2)
GO
INSERT [dbo].[Kavis_Birimler] ([Id], [BurbisId], [Kodu], [Baslik], [KurumId]) VALUES (60, 7, NULL, N'Dan��ma ve G�venlik', 2)
GO
INSERT [dbo].[Kavis_Birimler] ([Id], [BurbisId], [Kodu], [Baslik], [KurumId]) VALUES (61, 8, NULL, N'Denklik', 2)
GO
INSERT [dbo].[Kavis_Birimler] ([Id], [BurbisId], [Kodu], [Baslik], [KurumId]) VALUES (62, 9, NULL, N'DEPO (Destek Hizmetleri)', 2)
GO
INSERT [dbo].[Kavis_Birimler] ([Id], [BurbisId], [Kodu], [Baslik], [KurumId]) VALUES (63, 10, NULL, N'Destek Hizmetleri (Mutemetlik)', 2)
GO
INSERT [dbo].[Kavis_Birimler] ([Id], [BurbisId], [Kodu], [Baslik], [KurumId]) VALUES (64, 11, NULL, N'Destek Hizmetleri(B�t�e-Donat�m-Ta��n�r)', 2)
GO
INSERT [dbo].[Kavis_Birimler] ([Id], [BurbisId], [Kodu], [Baslik], [KurumId]) VALUES (65, 12, NULL, N'Din ��retimi', 2)
GO
INSERT [dbo].[Kavis_Birimler] ([Id], [BurbisId], [Kodu], [Baslik], [KurumId]) VALUES (66, 15, NULL, N'Evrak Kay�t', 2)
GO
INSERT [dbo].[Kavis_Birimler] ([Id], [BurbisId], [Kodu], [Baslik], [KurumId]) VALUES (67, 16, NULL, N'Genel', 2)
GO
INSERT [dbo].[Kavis_Birimler] ([Id], [BurbisId], [Kodu], [Baslik], [KurumId]) VALUES (68, 17, NULL, N'Hayat Boyu ��renme', 2)
GO
INSERT [dbo].[Kavis_Birimler] ([Id], [BurbisId], [Kodu], [Baslik], [KurumId]) VALUES (69, 18, NULL, N'Hukuk Hizmetleri', 2)
GO
INSERT [dbo].[Kavis_Birimler] ([Id], [BurbisId], [Kodu], [Baslik], [KurumId]) VALUES (70, 19, NULL, N'�l Enerji Y�netimi', 2)
GO
INSERT [dbo].[Kavis_Birimler] ([Id], [BurbisId], [Kodu], [Baslik], [KurumId]) VALUES (71, 20, NULL, N'�nceleme ve Rehberlik', 2)
GO
INSERT [dbo].[Kavis_Birimler] ([Id], [BurbisId], [Kodu], [Baslik], [KurumId]) VALUES (72, 21, NULL, N'�n�aat Emlak Hizmetleri(Emlak B�ro)', 2)
GO
INSERT [dbo].[Kavis_Birimler] ([Id], [BurbisId], [Kodu], [Baslik], [KurumId]) VALUES (73, 22, NULL, N'�n�aat Emlak Hizmetleri(�n�aat B�ro)', 2)
GO
INSERT [dbo].[Kavis_Birimler] ([Id], [BurbisId], [Kodu], [Baslik], [KurumId]) VALUES (74, 23, NULL, N'�n�aat Emlak Hizmetleri(Teknik B�ro)', 2)
GO
INSERT [dbo].[Kavis_Birimler] ([Id], [BurbisId], [Kodu], [Baslik], [KurumId]) VALUES (75, 24, NULL, N'�� G�venli�i', 2)
GO
INSERT [dbo].[Kavis_Birimler] ([Id], [BurbisId], [Kodu], [Baslik], [KurumId]) VALUES (76, 25, NULL, N'Kat G�revlisi', 2)
GO
INSERT [dbo].[Kavis_Birimler] ([Id], [BurbisId], [Kodu], [Baslik], [KurumId]) VALUES (77, 26, NULL, N'Mesleki ve Teknik E�itim', 2)
GO
INSERT [dbo].[Kavis_Birimler] ([Id], [BurbisId], [Kodu], [Baslik], [KurumId]) VALUES (78, 28, NULL, N'Orta ��retim', 2)
GO
INSERT [dbo].[Kavis_Birimler] ([Id], [BurbisId], [Kodu], [Baslik], [KurumId]) VALUES (79, 29, NULL, N'��retmen Atama', 2)
GO
INSERT [dbo].[Kavis_Birimler] ([Id], [BurbisId], [Kodu], [Baslik], [KurumId]) VALUES (80, 30, NULL, N'��retmen Yeti�tirme (Aday Performans)', 2)
GO
INSERT [dbo].[Kavis_Birimler] ([Id], [BurbisId], [Kodu], [Baslik], [KurumId]) VALUES (81, 31, NULL, N'��retmen Yeti�tirme (Hizmeti�i)', 2)
GO
INSERT [dbo].[Kavis_Birimler] ([Id], [BurbisId], [Kodu], [Baslik], [KurumId]) VALUES (82, 33, NULL, N'�zel B�ro', 2)
GO
INSERT [dbo].[Kavis_Birimler] ([Id], [BurbisId], [Kodu], [Baslik], [KurumId]) VALUES (83, 34, NULL, N'�zel E�itim ve Rehberlik', 2)
GO
INSERT [dbo].[Kavis_Birimler] ([Id], [BurbisId], [Kodu], [Baslik], [KurumId]) VALUES (84, 35, NULL, N'�zel Kalem', 2)
GO
INSERT [dbo].[Kavis_Birimler] ([Id], [BurbisId], [Kodu], [Baslik], [KurumId]) VALUES (85, 38, NULL, N'�zel ��retim', 2)
GO
INSERT [dbo].[Kavis_Birimler] ([Id], [BurbisId], [Kodu], [Baslik], [KurumId]) VALUES (86, 39, NULL, N'�zl�k-Terfi-Emeklilik', 2)
GO
INSERT [dbo].[Kavis_Birimler] ([Id], [BurbisId], [Kodu], [Baslik], [KurumId]) VALUES (87, 40, NULL, N'Pasaport', 2)
GO
INSERT [dbo].[Kavis_Birimler] ([Id], [BurbisId], [Kodu], [Baslik], [KurumId]) VALUES (88, 41, NULL, N'Personel Atama', 2)
GO
INSERT [dbo].[Kavis_Birimler] ([Id], [BurbisId], [Kodu], [Baslik], [KurumId]) VALUES (89, 43, NULL, N'Santral', 2)
GO
INSERT [dbo].[Kavis_Birimler] ([Id], [BurbisId], [Kodu], [Baslik], [KurumId]) VALUES (90, 44, NULL, N'S�nav Hizmetleri', 2)
GO
INSERT [dbo].[Kavis_Birimler] ([Id], [BurbisId], [Kodu], [Baslik], [KurumId]) VALUES (91, 45, NULL, N'Sivil Savunma', 2)
GO
INSERT [dbo].[Kavis_Birimler] ([Id], [BurbisId], [Kodu], [Baslik], [KurumId]) VALUES (92, 46, NULL, N'Strateji Geli�tirme', 2)
GO
INSERT [dbo].[Kavis_Birimler] ([Id], [BurbisId], [Kodu], [Baslik], [KurumId]) VALUES (93, 47, NULL, N'�of�rler', 2)
GO
INSERT [dbo].[Kavis_Birimler] ([Id], [BurbisId], [Kodu], [Baslik], [KurumId]) VALUES (94, 48, NULL, N'Ta��mal� E�itim', 2)
GO
INSERT [dbo].[Kavis_Birimler] ([Id], [BurbisId], [Kodu], [Baslik], [KurumId]) VALUES (95, 49, NULL, N'Teknik B�ro (Destek Hizmetleri)', 2)
GO
INSERT [dbo].[Kavis_Birimler] ([Id], [BurbisId], [Kodu], [Baslik], [KurumId]) VALUES (96, 50, NULL, N'Temel E�itim(Anaokulu-�lkokul)', 2)
GO
INSERT [dbo].[Kavis_Birimler] ([Id], [BurbisId], [Kodu], [Baslik], [KurumId]) VALUES (97, 51, NULL, N'Temel E�itim(Ortaokul)', 2)
GO
INSERT [dbo].[Kavis_Birimler] ([Id], [BurbisId], [Kodu], [Baslik], [KurumId]) VALUES (98, 52, NULL, N'Tesis M�d�rl���', 2)
GO
INSERT [dbo].[Kavis_Birimler] ([Id], [BurbisId], [Kodu], [Baslik], [KurumId]) VALUES (99, 54, NULL, N'Yemekhane', 2)
GO
INSERT [dbo].[Kavis_Birimler] ([Id], [BurbisId], [Kodu], [Baslik], [KurumId]) VALUES (100, 55, NULL, N'Y�netici Atama', 2)
GO
SET IDENTITY_INSERT [dbo].[Kavis_Birimler] OFF
GO
SET IDENTITY_INSERT [dbo].[Kavis_Eylemler] ON 
GO
INSERT [dbo].[Kavis_Eylemler] ([Id], [Birim], [StratejiId], [Kod], [Baslik], [SiraNo]) VALUES (1, N'55,56,57,58,59,60,64', 33, N'1.1.1.1', N'��rencilerin akademik ba�ar�s�, ilgi ve
yetenekleri do�rultusunda y�nlendirme �al��malar�n�n yap�lmas� i�in gerekli
tedbirler al�nacak, ��renci ve velilere bu konuda rehberlik yap�lacakt�r.', 1)
GO
INSERT [dbo].[Kavis_Eylemler] ([Id], [Birim], [StratejiId], [Kod], [Baslik], [SiraNo]) VALUES (2, NULL, 34, N'1.1.2.1', N'Her d�zey e�itim kademesinde ger�ekle�tirilen
sosyal, sanatsal ve sportif faaliyetlerin say�s� art�r�lacakt�r.', 1)
GO
INSERT [dbo].[Kavis_Eylemler] ([Id], [Birim], [StratejiId], [Kod], [Baslik], [SiraNo]) VALUES (3, NULL, 34, N'1.1.2.2', N'B�t�n e�itim kademelerinde bilimsel, k�lt�rel,
sanatsal, sportif ve toplum hizmeti alanlar�nda etkinliklere kat�l�m oran�
art�r�lacakt�r.�', 2)
GO
INSERT [dbo].[Kavis_Eylemler] ([Id], [Birim], [StratejiId], [Kod], [Baslik], [SiraNo]) VALUES (4, NULL, 35, N'1.1.3.1', N'Her d�zey e�itim kademesinde ger�ekle�tirilen
sosyal, sanatsal ve sportif faaliyetlerin say�s� art�r�lacakt�r.', 1)
GO
INSERT [dbo].[Kavis_Eylemler] ([Id], [Birim], [StratejiId], [Kod], [Baslik], [SiraNo]) VALUES (5, NULL, 43, N'1.2.1.1', N'null', 1)
GO
INSERT [dbo].[Kavis_Eylemler] ([Id], [Birim], [StratejiId], [Kod], [Baslik], [SiraNo]) VALUES (6, N'57,58', 33, N'1.1.1.2', N'��rencilerin ba�ar�s�n� art�rmak, sosyal,
sportif ve k�lt�rel faaliyetlerini ger�ekle�tirmeleri i�in yerel y�netimler ve
ilgili payda�larla i�birli�i �al��malar� yap�lacakt�r.', 2)
GO
INSERT [dbo].[Kavis_Eylemler] ([Id], [Birim], [StratejiId], [Kod], [Baslik], [SiraNo]) VALUES (7, NULL, 33, N'1.1.1.3', N'Erken �ocukluk e�itiminden ba�layarak �st
��renim kademelerinde de devam edecek �ekilde �ocuklar�n t�m geli�im
alanlar�n�n izlenmesi, de�erlendirilmesi ve iyile�tirilmesine y�nelik
Bakanl���m�z taraf�ndan kurulacak e-portfolyo, sistemi uygulanacakt�r.', 3)
GO
INSERT [dbo].[Kavis_Eylemler] ([Id], [Birim], [StratejiId], [Kod], [Baslik], [SiraNo]) VALUES (8, NULL, 33, N'1.1.1.4', N'Merkezi s�nav sonu�lar�n�n analizleri
yap�lacakt�r.', 4)
GO
INSERT [dbo].[Kavis_Eylemler] ([Id], [Birim], [StratejiId], [Kod], [Baslik], [SiraNo]) VALUES (9, NULL, 33, N'1.1.1.5', N'Hedeflenen ��renci n�fusunun (okul t�r�, b�lge,
cinsiyet, sosyo-ekonomik stat�) yeterlilik seviyeleri belirlenecek, y�llar
i�indeki de�i�imlerini takip etmek �zere veri toplanacakt�r.', 5)
GO
INSERT [dbo].[Kavis_Eylemler] ([Id], [Birim], [StratejiId], [Kod], [Baslik], [SiraNo]) VALUES (10, NULL, 33, N'1.1.1.6', N'�l genelinde Destek e�itimleri, destekleme ve
yeti�tirme kurslar�, ��renme g��l��� �eken ��rencilere y�nelik faaliyetler
ger�ekle�tirilecektir.', 6)
GO
INSERT [dbo].[Kavis_Eylemler] ([Id], [Birim], [StratejiId], [Kod], [Baslik], [SiraNo]) VALUES (11, NULL, 33, N'1.1.1.7', N'�limizde �l�me-de�erlendirme merkezlerinin etkin
ve verimli kullan�lmas�, yerel imk�nlardan yararlan�lmas�, okul-il�e-il
d�zeyinde s�navlara y�nelik ortak s�nav, tarama testleri, rehberlik
faaliyetleri gibi etkinlikler y�r�t�lecektir.', 7)
GO
INSERT [dbo].[Kavis_Eylemler] ([Id], [Birim], [StratejiId], [Kod], [Baslik], [SiraNo]) VALUES (12, N'56', 47, N'1.1.1.1', N'ddfgdfgdfgdfg', 1)
GO
INSERT [dbo].[Kavis_Eylemler] ([Id], [Birim], [StratejiId], [Kod], [Baslik], [SiraNo]) VALUES (13, N'55,57', 47, N'1.1.1.2', NULL, 2)
GO
INSERT [dbo].[Kavis_Eylemler] ([Id], [Birim], [StratejiId], [Kod], [Baslik], [SiraNo]) VALUES (14, N'56', 47, N'1.1.1.3', NULL, 3)
GO
INSERT [dbo].[Kavis_Eylemler] ([Id], [Birim], [StratejiId], [Kod], [Baslik], [SiraNo]) VALUES (15, N'55', 44, N'1.2.2.1', N'asdasdasdasdasdasd', 1)
GO
SET IDENTITY_INSERT [dbo].[Kavis_Eylemler] OFF
GO
SET IDENTITY_INSERT [dbo].[Kavis_Faaliyetler] ON 
GO
INSERT [dbo].[Kavis_Faaliyetler] ([Id], [EylemId], [Baslama], [Bitis], [Gerceklesme], [Sonuc], [Durum], [Birim], [Kod], [Baslik], [SiraNo], [BirimAdi], [Yil], [Onay1], [Onay2]) VALUES (2, 6, CAST(N'2021-10-06T00:00:00.000' AS DateTime), CAST(N'2021-10-29T00:00:00.000' AS DateTime), N'99999', N'9999', N'Devam Ediyor', 55, NULL, N'Faaliyet 1', 0, NULL, 0, 0, 0)
GO
INSERT [dbo].[Kavis_Faaliyetler] ([Id], [EylemId], [Baslama], [Bitis], [Gerceklesme], [Sonuc], [Durum], [Birim], [Kod], [Baslik], [SiraNo], [BirimAdi], [Yil], [Onay1], [Onay2]) VALUES (3, 7, CAST(N'2021-10-14T00:00:00.000' AS DateTime), CAST(N'2021-10-14T00:00:00.000' AS DateTime), N'ewrwerwerwerwer', N'werwerwer', N'Devam Ediyor', 55, NULL, N'faaliyet 2', 0, NULL, 0, 0, 0)
GO
INSERT [dbo].[Kavis_Faaliyetler] ([Id], [EylemId], [Baslama], [Bitis], [Gerceklesme], [Sonuc], [Durum], [Birim], [Kod], [Baslik], [SiraNo], [BirimAdi], [Yil], [Onay1], [Onay2]) VALUES (4, 8, CAST(N'2021-10-07T00:00:00.000' AS DateTime), NULL, NULL, NULL, N'�ptal Edildi', 55, NULL, N'asdasdasdasd', 0, NULL, 0, 0, 0)
GO
INSERT [dbo].[Kavis_Faaliyetler] ([Id], [EylemId], [Baslama], [Bitis], [Gerceklesme], [Sonuc], [Durum], [Birim], [Kod], [Baslik], [SiraNo], [BirimAdi], [Yil], [Onay1], [Onay2]) VALUES (7, 8, NULL, NULL, NULL, NULL, NULL, 55, NULL, N'tttttttttttttttttttttttt', 0, NULL, 0, 0, 0)
GO
INSERT [dbo].[Kavis_Faaliyetler] ([Id], [EylemId], [Baslama], [Bitis], [Gerceklesme], [Sonuc], [Durum], [Birim], [Kod], [Baslik], [SiraNo], [BirimAdi], [Yil], [Onay1], [Onay2]) VALUES (8, 1, NULL, NULL, NULL, NULL, NULL, 55, NULL, N'lllllllllllllllllllllll', 0, NULL, 0, 0, 0)
GO
SET IDENTITY_INSERT [dbo].[Kavis_Faaliyetler] OFF
GO
SET IDENTITY_INSERT [dbo].[Kavis_GostergeGirisleri] ON 
GO
INSERT [dbo].[Kavis_GostergeGirisleri] ([Id], [GostergeId], [Yil], [BirimId], [Onay], [Deger]) VALUES (1, 3, 2, 55, 0, N'5')
GO
INSERT [dbo].[Kavis_GostergeGirisleri] ([Id], [GostergeId], [Yil], [BirimId], [Onay], [Deger]) VALUES (2, 13, 2, 55, 0, N'6')
GO
INSERT [dbo].[Kavis_GostergeGirisleri] ([Id], [GostergeId], [Yil], [BirimId], [Onay], [Deger]) VALUES (3, 31, 3, 57, 0, N'56')
GO
SET IDENTITY_INSERT [dbo].[Kavis_GostergeGirisleri] OFF
GO
SET IDENTITY_INSERT [dbo].[Kavis_Gostergeler] ON 
GO
INSERT [dbo].[Kavis_Gostergeler] ([Id], [HedefeEtkisi], [Baslangic], [Yil1], [Yil2], [Yil3], [Yil4], [Yil5], [Yil1G], [Yil2G], [Yil3G], [Yil4G], [Yil5G], [Kod], [Baslik], [Hedef_Id], [SiraNo], [Izleme], [Rapor], [SorumluBirim], [SorumluBirimId]) VALUES (3, N'20', N'55,42', N'70', N'78', N'88', N'95', N'100', NULL, NULL, NULL, NULL, NULL, N'1.1.1.1', N'Bir e�itim ve ��retim d�neminde bilimsel, k�lt�rel, sanatsal ve sportif alanlarda en az bir faaliyete kat�lan ��renci oran� (%) - �lkokul', 1, 1, N'6 Ay', N'1 Y�l', N'ARGEAr�iv', N'55,56')
GO
INSERT [dbo].[Kavis_Gostergeler] ([Id], [HedefeEtkisi], [Baslangic], [Yil1], [Yil2], [Yil3], [Yil4], [Yil5], [Yil1G], [Yil2G], [Yil3G], [Yil4G], [Yil5G], [Kod], [Baslik], [Hedef_Id], [SiraNo], [Izleme], [Rapor], [SorumluBirim], [SorumluBirimId]) VALUES (12, N'20', N'51', N'60', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'1.1.1.2', N'Bir e�itim ve ��retim d�neminde bilimsel, k�lt�rel, sanatsal ve sportif alanlarda en az bir faaliyete kat�lan ��renci oran� (%) -Ortaokul', 1, 2, N'6 Ay', N'6 Ay', N'ARGE', N'55')
GO
INSERT [dbo].[Kavis_Gostergeler] ([Id], [HedefeEtkisi], [Baslangic], [Yil1], [Yil2], [Yil3], [Yil4], [Yil5], [Yil1G], [Yil2G], [Yil3G], [Yil4G], [Yil5G], [Kod], [Baslik], [Hedef_Id], [SiraNo], [Izleme], [Rapor], [SorumluBirim], [SorumluBirimId]) VALUES (13, N'20', N'65', N'70', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'1.1.1.3', N'Bir e�itim ve ��retim d�neminde bilimsel, k�lt�rel, sanatsal ve sportif alanlarda en az bir faaliyete kat�lan ��renci oran� (%) - Lise', 1, 3, N'6 Ay', N'6 Ay', N'', N'')
GO
INSERT [dbo].[Kavis_Gostergeler] ([Id], [HedefeEtkisi], [Baslangic], [Yil1], [Yil2], [Yil3], [Yil4], [Yil5], [Yil1G], [Yil2G], [Yil3G], [Yil4G], [Yil5G], [Kod], [Baslik], [Hedef_Id], [SiraNo], [Izleme], [Rapor], [SorumluBirim], [SorumluBirimId]) VALUES (18, N'60', N'74', N'75', N'76', N'77', N'78', N'80', NULL, NULL, NULL, NULL, NULL, N'1.2.1', N'Yabanc� dil dersi y�lsonu puan ortalamas�', 5, 1, N'6 Ay', N'6 Ay', N'', N'')
GO
INSERT [dbo].[Kavis_Gostergeler] ([Id], [HedefeEtkisi], [Baslangic], [Yil1], [Yil2], [Yil3], [Yil4], [Yil5], [Yil1G], [Yil2G], [Yil3G], [Yil4G], [Yil5G], [Kod], [Baslik], [Hedef_Id], [SiraNo], [Izleme], [Rapor], [SorumluBirim], [SorumluBirimId]) VALUES (19, N'40', N'5', N'50', N'200', N'400', N'800', N'1000', NULL, NULL, NULL, NULL, NULL, N'1.2.2', N'Yabanc� Dil Mesleki Geli�im Programlar�na kat�lan yabanc� dil ��retmeni say�s�', 5, 2, N'6 Ay', N'6 Ay', N'', N'')
GO
INSERT [dbo].[Kavis_Gostergeler] ([Id], [HedefeEtkisi], [Baslangic], [Yil1], [Yil2], [Yil3], [Yil4], [Yil5], [Yil1G], [Yil2G], [Yil3G], [Yil4G], [Yil5G], [Kod], [Baslik], [Hedef_Id], [SiraNo], [Izleme], [Rapor], [SorumluBirim], [SorumluBirimId]) VALUES (21, N'50', N'51478', N'73254', N'95647', N'102000', N'125478', N'155236', NULL, N'2', N'8', NULL, NULL, N'1.3.1', N'EBA Ders Portali ayl�k ortalama tekil ziyaret�i say�s�', 9, 1, N'6 Ay', N'6 Ay', N'', N'')
GO
INSERT [dbo].[Kavis_Gostergeler] ([Id], [HedefeEtkisi], [Baslangic], [Yil1], [Yil2], [Yil3], [Yil4], [Yil5], [Yil1G], [Yil2G], [Yil3G], [Yil4G], [Yil5G], [Kod], [Baslik], [Hedef_Id], [SiraNo], [Izleme], [Rapor], [SorumluBirim], [SorumluBirimId]) VALUES (22, N'25', N'520', N'600', N'675', N'750', N'825', N'900', NULL, N'2', N'9', NULL, NULL, N'�1.3.2.1', N'�EBA Ders Portali kullan�c� ba��na ayl�k ortalama sistemde kalma s�resi (dk.) - ��retmen', 9, 2, N'6 Ay', N'6 Ay', N'', N'')
GO
INSERT [dbo].[Kavis_Gostergeler] ([Id], [HedefeEtkisi], [Baslangic], [Yil1], [Yil2], [Yil3], [Yil4], [Yil5], [Yil1G], [Yil2G], [Yil3G], [Yil4G], [Yil5G], [Kod], [Baslik], [Hedef_Id], [SiraNo], [Izleme], [Rapor], [SorumluBirim], [SorumluBirimId]) VALUES (23, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'null', NULL, 1, NULL, NULL, N'(B�R�M SE��N�Z)', NULL)
GO
INSERT [dbo].[Kavis_Gostergeler] ([Id], [HedefeEtkisi], [Baslangic], [Yil1], [Yil2], [Yil3], [Yil4], [Yil5], [Yil1G], [Yil2G], [Yil3G], [Yil4G], [Yil5G], [Kod], [Baslik], [Hedef_Id], [SiraNo], [Izleme], [Rapor], [SorumluBirim], [SorumluBirimId]) VALUES (24, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'null', NULL, 2, NULL, NULL, N'(B�R�M SE��N�Z)', NULL)
GO
INSERT [dbo].[Kavis_Gostergeler] ([Id], [HedefeEtkisi], [Baslangic], [Yil1], [Yil2], [Yil3], [Yil4], [Yil5], [Yil1G], [Yil2G], [Yil3G], [Yil4G], [Yil5G], [Kod], [Baslik], [Hedef_Id], [SiraNo], [Izleme], [Rapor], [SorumluBirim], [SorumluBirimId]) VALUES (25, N'40', N'15,55', N'25', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'1.1.2.1', N'��renci ba��na okunan kitap say�s� -���lkokul', 1, 4, N'6 Ay', N'6 Ay', N'', N'')
GO
INSERT [dbo].[Kavis_Gostergeler] ([Id], [HedefeEtkisi], [Baslangic], [Yil1], [Yil2], [Yil3], [Yil4], [Yil5], [Yil1G], [Yil2G], [Yil3G], [Yil4G], [Yil5G], [Kod], [Baslik], [Hedef_Id], [SiraNo], [Izleme], [Rapor], [SorumluBirim], [SorumluBirimId]) VALUES (26, N'25', N'6835', N'7500', N'8000', N'8400', N'8750', N'9000', NULL, N'2', N'10', NULL, NULL, N'�1.3.2.1', N'EBA Ders Portali kullan�c� ba��na ayl�k ortalama sistemde kalma s�resi (dk.) - ��renci', 9, 3, N'6 Ay', N'6 Ay', N'', N'')
GO
INSERT [dbo].[Kavis_Gostergeler] ([Id], [HedefeEtkisi], [Baslangic], [Yil1], [Yil2], [Yil3], [Yil4], [Yil5], [Yil1G], [Yil2G], [Yil3G], [Yil4G], [Yil5G], [Kod], [Baslik], [Hedef_Id], [SiraNo], [Izleme], [Rapor], [SorumluBirim], [SorumluBirimId]) VALUES (27, N'40', N'10,06', N'11', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'1.1.2.2', N'��renci ba��na okunan kitap say�s� - Ortaokul', 1, 5, N'6 Ay', N'6 Ay', N'', N'')
GO
INSERT [dbo].[Kavis_Gostergeler] ([Id], [HedefeEtkisi], [Baslangic], [Yil1], [Yil2], [Yil3], [Yil4], [Yil5], [Yil1G], [Yil2G], [Yil3G], [Yil4G], [Yil5G], [Kod], [Baslik], [Hedef_Id], [SiraNo], [Izleme], [Rapor], [SorumluBirim], [SorumluBirimId]) VALUES (28, N'40', N'6', N'7', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'1.1.2.3', N'��renci ba��na okunan kitap say�s� - Lise', 1, 6, N'6 Ay', N'6 Ay', N'', N'')
GO
INSERT [dbo].[Kavis_Gostergeler] ([Id], [HedefeEtkisi], [Baslangic], [Yil1], [Yil2], [Yil3], [Yil4], [Yil5], [Yil1G], [Yil2G], [Yil3G], [Yil4G], [Yil5G], [Kod], [Baslik], [Hedef_Id], [SiraNo], [Izleme], [Rapor], [SorumluBirim], [SorumluBirimId]) VALUES (29, N'40', N'12', N'11', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'1.1.3', N'Orta��retime merkezi s�navla yerle�en ��renci oran� (%)', 1, 7, N'6 Ay', N'6 Ay', N'', N'')
GO
INSERT [dbo].[Kavis_Gostergeler] ([Id], [HedefeEtkisi], [Baslangic], [Yil1], [Yil2], [Yil3], [Yil4], [Yil5], [Yil1G], [Yil2G], [Yil3G], [Yil4G], [Yil5G], [Kod], [Baslik], [Hedef_Id], [SiraNo], [Izleme], [Rapor], [SorumluBirim], [SorumluBirimId]) VALUES (31, N'10', N'24', N'25', N'26', N'27', N'28', N'29', NULL, NULL, NULL, NULL, NULL, NULL, N'Deneme g�sterge', 3, 1, N'6 Ay', N'6 Ay', N'ARGEAr�ivAvukatlar', N'55,56,57')
GO
INSERT [dbo].[Kavis_Gostergeler] ([Id], [HedefeEtkisi], [Baslangic], [Yil1], [Yil2], [Yil3], [Yil4], [Yil5], [Yil1G], [Yil2G], [Yil3G], [Yil4G], [Yil5G], [Kod], [Baslik], [Hedef_Id], [SiraNo], [Izleme], [Rapor], [SorumluBirim], [SorumluBirimId]) VALUES (32, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'null', 11, 1, NULL, N'6 Ay', N'ARGE', N'55')
GO
INSERT [dbo].[Kavis_Gostergeler] ([Id], [HedefeEtkisi], [Baslangic], [Yil1], [Yil2], [Yil3], [Yil4], [Yil5], [Yil1G], [Yil2G], [Yil3G], [Yil4G], [Yil5G], [Kod], [Baslik], [Hedef_Id], [SiraNo], [Izleme], [Rapor], [SorumluBirim], [SorumluBirimId]) VALUES (33, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'null', 11, 2, NULL, NULL, N'', N'')
GO
INSERT [dbo].[Kavis_Gostergeler] ([Id], [HedefeEtkisi], [Baslangic], [Yil1], [Yil2], [Yil3], [Yil4], [Yil5], [Yil1G], [Yil2G], [Yil3G], [Yil4G], [Yil5G], [Kod], [Baslik], [Hedef_Id], [SiraNo], [Izleme], [Rapor], [SorumluBirim], [SorumluBirimId]) VALUES (34, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'j', 13, 1, NULL, NULL, N'ARGEAr�iv', N'55,56')
GO
INSERT [dbo].[Kavis_Gostergeler] ([Id], [HedefeEtkisi], [Baslangic], [Yil1], [Yil2], [Yil3], [Yil4], [Yil5], [Yil1G], [Yil2G], [Yil3G], [Yil4G], [Yil5G], [Kod], [Baslik], [Hedef_Id], [SiraNo], [Izleme], [Rapor], [SorumluBirim], [SorumluBirimId]) VALUES (35, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'hj', 13, 2, NULL, NULL, N'', N'')
GO
SET IDENTITY_INSERT [dbo].[Kavis_Gostergeler] OFF
GO
SET IDENTITY_INSERT [dbo].[Kavis_Hedefler] ON 
GO
INSERT [dbo].[Kavis_Hedefler] ([Id], [Kod], [Baslik], [Amac_Id], [SiraNo]) VALUES (1, N'1.1', N'T�m alanlarda ve e�itim kademelerinde, ��rencilerimizin her d�zeydeki yeterliliklerinin belirlenmesi, izlenmesi ve desteklenmesi i�in kurulacak �l�me ve de�erlendirme sistemine il d�zeyinde i�lerlik kazand�r�lacakt�r.', 1, 1)
GO
INSERT [dbo].[Kavis_Hedefler] ([Id], [Kod], [Baslik], [Amac_Id], [SiraNo]) VALUES (3, N'2.1', N'YEN� HEDEF', 2, 1)
GO
INSERT [dbo].[Kavis_Hedefler] ([Id], [Kod], [Baslik], [Amac_Id], [SiraNo]) VALUES (4, N'2.2', N'YEN� HEDEF', 2, 2)
GO
INSERT [dbo].[Kavis_Hedefler] ([Id], [Kod], [Baslik], [Amac_Id], [SiraNo]) VALUES (5, N'1.2', N'��rencilerin ya�, okul t�r� ve programlar�na g�re gereksinimlerini dikkate alan beceri temelli yabanc� dil yeterlilikleri sistemine ge�ilmesine ili�kin etkin �al��malar y�r�t�lecektir.', 1, 2)
GO
INSERT [dbo].[Kavis_Hedefler] ([Id], [Kod], [Baslik], [Amac_Id], [SiraNo]) VALUES (9, N'1.3', N'��renme s�re�lerini destekleyen dijital i�erik ve beceri destekli d�n���m ile �lkemizin her yerinde ya�ayan ��renci ve ��retmenlerimizin e�it ��renme ve ��retme f�rsatlar�n� yakalamalar� ve ��renmenin s�n�f duvarlar�n� a�mas� sa�lanacakt�r.', 1, 3)
GO
INSERT [dbo].[Kavis_Hedefler] ([Id], [Kod], [Baslik], [Amac_Id], [SiraNo]) VALUES (11, N'3.1', N'YEN� HEDEF', 6, 1)
GO
INSERT [dbo].[Kavis_Hedefler] ([Id], [Kod], [Baslik], [Amac_Id], [SiraNo]) VALUES (13, N'1.1', N'YEN� HEDEF', 9, 1)
GO
SET IDENTITY_INSERT [dbo].[Kavis_Hedefler] OFF
GO
SET IDENTITY_INSERT [dbo].[Kavis_Kurumlar] ON 
GO
INSERT [dbo].[Kavis_Kurumlar] ([Id], [KurumKodu], [Adi], [Turu], [AktifPlanId], [AktifYil], [FaaliyetGirisAcik], [FaaliyetDurumGirisAcik], [GostergeGirisAcik], [Mesaj]) VALUES (2, 123333, N'�L M�LL� E��T�M M�D�RL���', 0, 1, 3, 0, 1, 1, N'<p>ppppppa</p>')
GO
INSERT [dbo].[Kavis_Kurumlar] ([Id], [KurumKodu], [Adi], [Turu], [AktifPlanId], [AktifYil], [FaaliyetGirisAcik], [FaaliyetDurumGirisAcik], [GostergeGirisAcik], [Mesaj]) VALUES (3, 3434, N'DENEME KURUMU', 2, 2, 0, 1, 0, 1, N'<p>������</p>')
GO
SET IDENTITY_INSERT [dbo].[Kavis_Kurumlar] OFF
GO
SET IDENTITY_INSERT [dbo].[Kavis_Plans] ON 
GO
INSERT [dbo].[Kavis_Plans] ([Id], [Baslangic], [Bitis], [KurumId]) VALUES (1, 2019, 2023, 2)
GO
INSERT [dbo].[Kavis_Plans] ([Id], [Baslangic], [Bitis], [KurumId]) VALUES (7, 2025, 2029, 2)
GO
SET IDENTITY_INSERT [dbo].[Kavis_Plans] OFF
GO
SET IDENTITY_INSERT [dbo].[Kavis_Stratejiler] ON 
GO
INSERT [dbo].[Kavis_Stratejiler] ([Id], [Kod], [Baslik], [Hedef_Id], [SiraNo]) VALUES (33, N'1.1.1', N'E�itim kalitesinin art�r�lmas� i�in �l�me ve de�erlendirme y�ntemleri etkinle�tirilecek ve yeterlilik temelli �l�me de�erlendirme yap�lacakt�r.', 1, 1)
GO
INSERT [dbo].[Kavis_Stratejiler] ([Id], [Kod], [Baslik], [Hedef_Id], [SiraNo]) VALUES (34, N'1.1.2', N'��rencilerin bilimsel, k�lt�rel, sanatsal, sportif ve toplum hizmeti alanlar�nda etkinliklere kat�l�m� art�r�lacak ve izlenecektir.', 1, 2)
GO
INSERT [dbo].[Kavis_Stratejiler] ([Id], [Kod], [Baslik], [Hedef_Id], [SiraNo]) VALUES (35, N'1.1.3', N'Kademeler aras� ge�i� s�navlar�n�n ��renciler �zerindeki bask�s�n� azaltacak �al��malar yap�lacakt�r.', 1, 3)
GO
INSERT [dbo].[Kavis_Stratejiler] ([Id], [Kod], [Baslik], [Hedef_Id], [SiraNo]) VALUES (41, N'2.2.1', NULL, 4, 1)
GO
INSERT [dbo].[Kavis_Stratejiler] ([Id], [Kod], [Baslik], [Hedef_Id], [SiraNo]) VALUES (42, N'2.2.2', NULL, 4, 2)
GO
INSERT [dbo].[Kavis_Stratejiler] ([Id], [Kod], [Baslik], [Hedef_Id], [SiraNo]) VALUES (43, N'1.2.1', N'�l genelinde yabanc� dil e�itimi, seviye ve okul t�rlerine g�re uyarlanacakt�r.', 5, 1)
GO
INSERT [dbo].[Kavis_Stratejiler] ([Id], [Kod], [Baslik], [Hedef_Id], [SiraNo]) VALUES (44, N'1.2.2', N'Yeni kaynaklar ile ��rencilerin �ngilizce konu�ulan d�nyay� deneyimlemesi ve Bakanl�k�a geli�tirilecek olan dijital i�erikleri kullanmalar� sa�lanacakt�r.', 5, 2)
GO
INSERT [dbo].[Kavis_Stratejiler] ([Id], [Kod], [Baslik], [Hedef_Id], [SiraNo]) VALUES (45, N'1.2.3', N'Yabanc� dil e�itiminde ��retmen nitelik ve yeterlilikleri y�kseltilecektir.', 5, 3)
GO
INSERT [dbo].[Kavis_Stratejiler] ([Id], [Kod], [Baslik], [Hedef_Id], [SiraNo]) VALUES (47, N'1.1.1', N'�stratejimmm', 13, 1)
GO
INSERT [dbo].[Kavis_Stratejiler] ([Id], [Kod], [Baslik], [Hedef_Id], [SiraNo]) VALUES (48, N'1.1.2', N'�hjkhjkhjk', 13, 2)
GO
INSERT [dbo].[Kavis_Stratejiler] ([Id], [Kod], [Baslik], [Hedef_Id], [SiraNo]) VALUES (49, N'1.1.3', N'�hkhjkhjk', 13, 3)
GO
SET IDENTITY_INSERT [dbo].[Kavis_Stratejiler] OFF
GO
/****** Object:  Index [IX_StratejikPlanId]    Script Date: 12.11.2021 14:35:45 ******/
CREATE NONCLUSTERED INDEX [IX_StratejikPlanId] ON [dbo].[Kavis_Amaclar]
(
	[StratejikPlanId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_KurumId]    Script Date: 12.11.2021 14:35:45 ******/
CREATE NONCLUSTERED INDEX [IX_KurumId] ON [dbo].[Kavis_Birimler]
(
	[KurumId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_StratejiId]    Script Date: 12.11.2021 14:35:45 ******/
CREATE NONCLUSTERED INDEX [IX_StratejiId] ON [dbo].[Kavis_Eylemler]
(
	[StratejiId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_EylemId]    Script Date: 12.11.2021 14:35:45 ******/
CREATE NONCLUSTERED INDEX [IX_EylemId] ON [dbo].[Kavis_Faaliyetler]
(
	[EylemId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_BirimId]    Script Date: 12.11.2021 14:35:45 ******/
CREATE NONCLUSTERED INDEX [IX_BirimId] ON [dbo].[Kavis_GostergeGirisleri]
(
	[BirimId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_GostergeId]    Script Date: 12.11.2021 14:35:45 ******/
CREATE NONCLUSTERED INDEX [IX_GostergeId] ON [dbo].[Kavis_GostergeGirisleri]
(
	[GostergeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Hedef_Id]    Script Date: 12.11.2021 14:35:45 ******/
CREATE NONCLUSTERED INDEX [IX_Hedef_Id] ON [dbo].[Kavis_Gostergeler]
(
	[Hedef_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Amac_Id]    Script Date: 12.11.2021 14:35:45 ******/
CREATE NONCLUSTERED INDEX [IX_Amac_Id] ON [dbo].[Kavis_Hedefler]
(
	[Amac_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_KurumId]    Script Date: 12.11.2021 14:35:45 ******/
CREATE NONCLUSTERED INDEX [IX_KurumId] ON [dbo].[Kavis_Plans]
(
	[KurumId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Hedef_Id]    Script Date: 12.11.2021 14:35:45 ******/
CREATE NONCLUSTERED INDEX [IX_Hedef_Id] ON [dbo].[Kavis_Stratejiler]
(
	[Hedef_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Kavis_Amaclar] ADD  DEFAULT ((0)) FOR [SiraNo]
GO
ALTER TABLE [dbo].[Kavis_Faaliyetler] ADD  DEFAULT ((0)) FOR [Yil]
GO
ALTER TABLE [dbo].[Kavis_Faaliyetler] ADD  DEFAULT ((0)) FOR [Onay1]
GO
ALTER TABLE [dbo].[Kavis_Faaliyetler] ADD  DEFAULT ((0)) FOR [Onay2]
GO
ALTER TABLE [dbo].[Kavis_Gostergeler] ADD  DEFAULT ((0)) FOR [SiraNo]
GO
ALTER TABLE [dbo].[Kavis_Hedefler] ADD  DEFAULT ((0)) FOR [SiraNo]
GO
ALTER TABLE [dbo].[Kavis_Kurumlar] ADD  DEFAULT ((0)) FOR [AktifYil]
GO
ALTER TABLE [dbo].[Kavis_Kurumlar] ADD  DEFAULT ((0)) FOR [FaaliyetGirisAcik]
GO
ALTER TABLE [dbo].[Kavis_Kurumlar] ADD  DEFAULT ((0)) FOR [FaaliyetDurumGirisAcik]
GO
ALTER TABLE [dbo].[Kavis_Kurumlar] ADD  DEFAULT ((0)) FOR [GostergeGirisAcik]
GO
ALTER TABLE [dbo].[Kavis_Plans] ADD  DEFAULT ((0)) FOR [KurumId]
GO
ALTER TABLE [dbo].[Kavis_Stratejiler] ADD  DEFAULT ((0)) FOR [SiraNo]
GO
ALTER TABLE [dbo].[Kavis_Amaclar]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Amaclar_dbo.Plans_StratejikPlanId] FOREIGN KEY([StratejikPlanId])
REFERENCES [dbo].[Kavis_Plans] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Kavis_Amaclar] CHECK CONSTRAINT [FK_dbo.Amaclar_dbo.Plans_StratejikPlanId]
GO
ALTER TABLE [dbo].[Kavis_Birimler]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Birimler_dbo.Kurumlar_KurumId] FOREIGN KEY([KurumId])
REFERENCES [dbo].[Kavis_Kurumlar] ([Id])
GO
ALTER TABLE [dbo].[Kavis_Birimler] CHECK CONSTRAINT [FK_dbo.Birimler_dbo.Kurumlar_KurumId]
GO
ALTER TABLE [dbo].[Kavis_Eylemler]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Eylemler_dbo.Stratejiler_StratejiId] FOREIGN KEY([StratejiId])
REFERENCES [dbo].[Kavis_Stratejiler] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Kavis_Eylemler] CHECK CONSTRAINT [FK_dbo.Eylemler_dbo.Stratejiler_StratejiId]
GO
ALTER TABLE [dbo].[Kavis_Faaliyetler]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Faaliyetler_dbo.Eylemler_EylemId] FOREIGN KEY([EylemId])
REFERENCES [dbo].[Kavis_Eylemler] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Kavis_Faaliyetler] CHECK CONSTRAINT [FK_dbo.Faaliyetler_dbo.Eylemler_EylemId]
GO
ALTER TABLE [dbo].[Kavis_GostergeGirisleri]  WITH CHECK ADD  CONSTRAINT [FK_dbo.GostergeGirisleri_dbo.Birimler_BirimId] FOREIGN KEY([BirimId])
REFERENCES [dbo].[Kavis_Birimler] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Kavis_GostergeGirisleri] CHECK CONSTRAINT [FK_dbo.GostergeGirisleri_dbo.Birimler_BirimId]
GO
ALTER TABLE [dbo].[Kavis_GostergeGirisleri]  WITH CHECK ADD  CONSTRAINT [FK_dbo.GostergeGirisleri_dbo.Gostergeler_GostergeId] FOREIGN KEY([GostergeId])
REFERENCES [dbo].[Kavis_Gostergeler] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Kavis_GostergeGirisleri] CHECK CONSTRAINT [FK_dbo.GostergeGirisleri_dbo.Gostergeler_GostergeId]
GO
ALTER TABLE [dbo].[Kavis_Gostergeler]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Gostergeler_dbo.Hedefler_Hedef_Id] FOREIGN KEY([Hedef_Id])
REFERENCES [dbo].[Kavis_Hedefler] ([Id])
GO
ALTER TABLE [dbo].[Kavis_Gostergeler] CHECK CONSTRAINT [FK_dbo.Gostergeler_dbo.Hedefler_Hedef_Id]
GO
ALTER TABLE [dbo].[Kavis_Hedefler]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Hedefler_dbo.Amaclar_Amac_Id] FOREIGN KEY([Amac_Id])
REFERENCES [dbo].[Kavis_Amaclar] ([Id])
GO
ALTER TABLE [dbo].[Kavis_Hedefler] CHECK CONSTRAINT [FK_dbo.Hedefler_dbo.Amaclar_Amac_Id]
GO
ALTER TABLE [dbo].[Kavis_Plans]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Plans_dbo.Kurumlar_KurumId] FOREIGN KEY([KurumId])
REFERENCES [dbo].[Kavis_Kurumlar] ([Id])
GO
ALTER TABLE [dbo].[Kavis_Plans] CHECK CONSTRAINT [FK_dbo.Plans_dbo.Kurumlar_KurumId]
GO
ALTER TABLE [dbo].[Kavis_Stratejiler]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Stratejiler_dbo.Hedefler_Hedef_Id] FOREIGN KEY([Hedef_Id])
REFERENCES [dbo].[Kavis_Hedefler] ([Id])
GO
ALTER TABLE [dbo].[Kavis_Stratejiler] CHECK CONSTRAINT [FK_dbo.Stratejiler_dbo.Hedefler_Hedef_Id]