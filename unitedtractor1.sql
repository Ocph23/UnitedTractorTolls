﻿# Host: localhost  (Version: 5.5.36)
# Date: 2016-04-05 12:59:59
# Generator: MySQL-Front 5.3  (Build 4.4)

/*!40101 SET NAMES utf8 */;

#
# Source for table "hargasewa"
#

DROP TABLE IF EXISTS `hargasewa`;
CREATE TABLE `hargasewa` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `TollsId` int(11) NOT NULL DEFAULT '0',
  `Harga` double NOT NULL DEFAULT '0',
  `Denda` double NOT NULL DEFAULT '0',
  `Aktif` enum('true','false') NOT NULL DEFAULT 'true',
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=latin1;

#
# Data for table "hargasewa"
#

INSERT INTO `hargasewa` VALUES (5,4,30000,20000,'true'),(6,5,30000,5000,'true');

#
# Source for table "history"
#

DROP TABLE IF EXISTS `history`;
CREATE TABLE `history` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Tanggal` datetime NOT NULL DEFAULT '0000-00-00 00:00:00',
  `Keterangan` tinytext NOT NULL,
  `PetugasID` int(11) NOT NULL DEFAULT '0',
  `PetugasName` int(11) NOT NULL DEFAULT '0',
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

#
# Data for table "history"
#


#
# Source for table "kategori"
#

DROP TABLE IF EXISTS `kategori`;
CREATE TABLE `kategori` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Kode` varchar(15) NOT NULL DEFAULT '',
  `Nama` varchar(255) NOT NULL DEFAULT '',
  `Keterangan` tinytext NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;

#
# Data for table "kategori"
#

INSERT INTO `kategori` VALUES (1,'PKS','Perkakas','Ini Keterangan'),(2,'PJP','Penjepit','tolls Penjepit');

#
# Source for table "pelanggan"
#

DROP TABLE IF EXISTS `pelanggan`;
CREATE TABLE `pelanggan` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `NIK` varchar(20) NOT NULL DEFAULT '',
  `Nama` varchar(255) NOT NULL DEFAULT '',
  `Jabatan` varchar(255) NOT NULL DEFAULT '',
  `Alamat` tinytext NOT NULL,
  `Email` varchar(50) NOT NULL DEFAULT '',
  `Hp` varchar(20) NOT NULL DEFAULT '',
  `Photo` blob,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=14 DEFAULT CHARSET=latin1;

#
# Data for table "pelanggan"
#

INSERT INTO `pelanggan` VALUES (2,'03404303430430','Yoseph Kungkung','Direktur','ini alamat','Ocph@gmail.com','0812334',X'FFD8FFE000104A46494600010101006000600000FFDB004300080606070605080707070909080A0C140D0C0B0B0C1912130F141D1A1F1E1D1A1C1C20242E2720222C231C1C2837292C30313434341F27393D38323C2E333432FFDB0043010909090C0B0C180D0D1832211C213232323232323232323232323232323232323232323232323232323232323232323232323232323232323232323232323232FFC0001108009800C803012200021101031101FFC4001F0000010501010101010100000000000000000102030405060708090A0BFFC400B5100002010303020403050504040000017D01020300041105122131410613516107227114328191A1082342B1C11552D1F02433627282090A161718191A25262728292A3435363738393A434445464748494A535455565758595A636465666768696A737475767778797A838485868788898A92939495969798999AA2A3A4A5A6A7A8A9AAB2B3B4B5B6B7B8B9BAC2C3C4C5C6C7C8C9CAD2D3D4D5D6D7D8D9DAE1E2E3E4E5E6E7E8E9EAF1F2F3F4F5F6F7F8F9FAFFC4001F0100030101010101010101010000000000000102030405060708090A0BFFC400B51100020102040403040705040400010277000102031104052131061241510761711322328108144291A1B1C109233352F0156272D10A162434E125F11718191A262728292A35363738393A434445464748494A535455565758595A636465666768696A737475767778797A82838485868788898A92939495969798999AA2A3A4A5A6A7A8A9AAB2B3B4B5B6B7B8B9BAC2C3C4C5C6C7C8C9CAD2D3D4D5D6D7D8D9DAE2E3E4E5E6E7E8E9EAF2F3F4F5F6F7F8F9FAFFDA000C03010002110311003F00F518A0F6AB896FED5623B71F855C8E118E95D72A8704291523B6E1BE950BDB7B56C2C43078A8DA107B566AA6A6CE968604B07B551960AE865847A553921118DE473D856F0A87254A4604B6EB129661F31E82B3A48B73163D4D6DCE859B26AA3435DB4E479B5A3D118ED053A382B44C23D29C907B5747B5D0F3A71D4A6B6DED4FFB37B5682C5ED4BE57B564EAB33E46CC97B7F6AAB2C1815B8D18C74AA93C3C5690AAEE4B8B460CB0D51963EB5B7347ED59D3A735D7195D0EC64BA5576157A55AAC533D2AD32AC546151115A22D5D870A698D67263EE9AA5342E5666D255DFB04CDD169CBA4DCC8E1238D9D8F40A3355CC89B6B633E8AB975A6DD5A3ED9E22BE841041FA11D7F0AA84107078A69A7AA069ADC4A28A2981F47C0BC62AE05C0AAD055A1D2BE324F53EE29EC28A6914FA4C541A58AF2281CD66DC0C939CD6B4838ACD9D7DAB6A6CE6ACB431E64E6AB94AD0953DAA1D9ED5DB091E45629F95CF4A5098ED56FCB06944393D2AF98E094752B843E94A633E956C43ED4FF002EA798B51D0CD788D559A338AD878FDAAACD171D2AE1230A9139E9D2B3275E4D6EDCC59E2B3A4B639E95DF4DE865A188F1963800D4F6DA79C6F7181F4AD6B3B3469807E066B6351B5823814478FC28A955C65CA7453A5CD1E632ACAC04C42A20AD73A1C623CBA01F851A40585BE61D3AD68DFEA1108CAA9FD6B8E739F3D91D90A74DD3BB39DB8B2B5B64795C7EED481851CB1FE9D2B3E4D42329E5222C71FF00757BFD4F7AB5A85C87D32520F4957BFB35722F77CF5AEEA31725EF1E6565CBA44E8A3922643190AD1B0E6371953FE07DC73593AA68B1792D7106E5008528DCF5CF20F71C77C7E350C1744B0E6B7AD184F632A3F42E9FC9AB57EE3BA328B7B1C1BA3236D228ADFD5B4BF2CB328FA1A2B6534C7667B9452211C0AB2A41158D6F2FBD6AC670A39AF909C6C7DA51A9CC89A8A40734D2D599BDC538EF50398F072B9A918D5690D5C518D595915E630FF72AA1921FEE55A68F7544D6C3D2BA636479951CA5D084188FF054CB12B7418A161C1AB31A803A5394ADB18469B94B520316298C957180C54256A548A9D2E5D8A6CB55E41571C55593A9ADA0CE3AB0283401B922ABC96A3D2B4F029A541AE98D468E0A89A317C931B6E03A1A9648DE440F236C4F7E49FA0FF22B5044A1646C0CAAE464743903FAD65CC48989624927A935AC66E6F432555C2D7EA3FCFF00B3C03C950BFED30C9359575771CFC3379327AF543FD47F2F615A33956801F4AE76FE58E3DDCE4D694E9A7AF53A15796C477B28B7B592DAE99A22EC196403729C023B751CF519E95CD5D5BCF6C54B80D1B7DD911B72B7D0FF004EA3BD6843792CF78B6EE435BC9C346C323A75F63EE39ACBB7BA9AD58EC20A37DE461956FA8E9FE78AEBA719444DC5A4D96EC2296EA611C4858F7C741F52781F8D761A640AB1F92AE2466604B2FDD18CF43DFAF5AE522BC9272A8152184748A2185FC73924FB924D769E1E640CBBAB1C4CA4A3736C3C20E562EDF68C64B5076F6F4A2BAC9A680591C91F778A2BCD8626763D5960E9AEA51B69044A1DCFCC7A2D6847739E735CC5BDC33BEE63926B5619BE51594E89CD4F1C93B237A193706F614CF32AB594C1849CF45A80CC39E6B97D9EAD1EA7D6D72464FA9A1E70E87A531C7CDC1C83540CFC75A9EDAE063079069F235A99FD6A337CACB000C52EDA4E074E94E06914AC34A537A54B51BF4A1306BA8DDD4C340A0F4AA26D72BCB54E4AB9255396B683396B4511E68C8A8CB62A379B1DEBA12B9E55544E5C08663FEC0FFD08561DD4A5A4E013DEAE9B90CB34619433A61727193B81C67E80D616A13B46C62DA57E504A91839C0AE9C3D3F7AC72CE9DD293FEB565D0E8612090CDE9D07E7583A85B0909F28FCE7F809E7F0F5A23D43CB9304D5F11477D1B3875555196CD7572FB3771C75E873569015D4A1041043E083508D27CB62B773A5BB9E91B02581FF680FBA3EBCFB57591C463C4D126D48986EB8971BCF0781E9DB8193EF58D1D8EC1B88C93EB5519B6DF4357CB18AEA558B4C9EDCAB480146FBAEBCA9FA1AE8B4DDF16DAA96AB2C2484C6D6FBC84641FA8357FCC8106202239CFF0124A9FA1FE87F3A8A8DBD18425AFBA59D4F5930C5E5EEE828AE3752BC372095ED455470D148D7EB32676D04B8EF5A11DC6075AC48DF153ACFEF5CD2A773E7FEB6D33A5B1B9C0979FE1A83ED1CF5ACFB4B8C0939FE1A609BDEB9FD8DA4CEC7983F67057EE69F9F9EF53C13ED2066B2165A992420839A4E9E8552C6BE6B9D245302315367DEB0A0BBC704F35752F17A13C5724E934F43E8286314A3A9A5B862A267CF1557ED20F434A1C9EB51C963A7DBA64E0D231E299BB14D67CD2B16A7A0C735564E9561CD5690D6B1473D59685398E01ACF9E5D83E63D7B55DB861597747739AEDA48E192B94AE2EFB6063D2AB5D5C972B13A8963F2D70AC70CBF28E54FF004FD2A4963C9A60896475F30152300301E9EB5D37442563226B3337CF692799EA8D8574FCFB7BFE78AB767771D85ADD1DEB7322AAE40CF963E61C67AB63DB8FAD366B260B923E53D187434C4B2CD8DD973B10AA72475F98568DDD6AC956BBB2EFF916575CF3E0669886C3A803180383D3D2A56D4A0118F954D7337036A148D0AAE73927938E07F3A759A35C7EEC9E6B5E48A5739DAE666A5CEB21410BC7A62A858DEC971AAC20938CB7FE826AD5CE853450798578F5AA5A6405356878E32DFF00A09A2F17076358D3709C6FDD15A324C4D93DA8A6C8E238B1DCD15B989DCF6A4C914BDA9A6B88F98913C3215DDCF514F56F7AAEA715221A4C71D6C8B88D536FC0AA6AF8A7190D64D1DF42372C89B07AD4E931F5ACE5624D5A8EB099ED515634E19B8E6AE24B9ACA426AD46E4561247A103437D213502C94A64ACB94DF9AC398D5599F029F24B54A692B4844CE4EE413BE6AA4ABE636477ED52BBE6A2DB935D51D0C595FC9C9A945A851961CFA55C4538ED9F5C75A7BAF39F5143A85469DF5331A12B900704723154A58DA32CCCA24471860F9E47F4AD975155A7881415719EBA913A565A1CD5C69C9396368496EA227E1BF0FEF7E1CFB56640FF679F2782A79CD6EDE438354A7697CADD7564B7217952EC438FAE0E4AFD7F022BB149DBB9CABE2ECCD26D624BDB23105558D07CF239C2AFD4FF41C9AC09B5382D8FF00A28F327E73332E02FF00BABFD4FE42A85DDE4F70C3CD6F947DD4501557E8074AA86AE9D15146952BB931598B1A2928ADCE73D08352D570F53CA427978FE2406B89A3E6E50DD8E14F5205570F524EC16E2455E003C52B0420F726DD46EA8A160D346A7A1600D01BE6FC6A25A687A34236D4B319E6ADC66AA41CB1FA1FE5562335CD23D5A45D43C54EA6AB47F76A55358B3BA0C9C36290C869B9F96984D4A46B711E4355646A9A4E00FA55590D69144B6465B9A7275A8DF86A746DF30FAD6B6336CBABD2949E39E6A357A90727F0AC9EE7445E844C57B55793906A761C542E0EC6F51571267B19F7444506F551BC92031E71D3A7BFBD73172CCB27981983F5DD9E7F3AE92F033C223CAABEE3807BFB67D78E958E6D59E16730349289446B19078382791D7B74AEDA2D25A9C151372D0C5BA2B35A7DA0AA897CCDA4A8C678CF4F5ACF35D3FD95678A3B49D51D9E51CC400F2F8C0E8307FCF359D3690E88B807BF3F8D74C26B62276DCC9A2AC4B692467A515ADCCCEC60398E623B803F33FF00D6A75CC8408BD931FA9A8E09079DF2A85C7CC79F4E692460E8B2B2862463F535C29BB9E5B8A712789B30A01C932723DB14C9A426624F700FE829B0CA563774017CBC103EB91FD6924DA3CB25724A039C9F4145F51282E5562D2123C96EBB51BF3E4D28E1DBEA69892916C48E32C53E8303FC2A4242CAD95CFAF35933AA36B685E5FBEC7B04001FC853A2E5947A9A85243B1074DD927F335206DAC401C8E339AC9A3B62CBA0F0C7D4D4B1B73F85570E490BEC3FA5395F9FC6B268EB8C8B1BB0829BBB83F4A617C86CF63C53438271FD6A6C5F304A781F4AACE7F77F8D4923E46EF7A80C98048FE1E6B4484E4412BE5CE29C927FABFA93504CDF2A9F5F7A21909427F0AD52D087234222771CFAD5D0EA0E48E8B594F32C7C639239E693ED67681D9B39E7DEA5C2E38D4B1A2645271514AE1965DA71B8707F1ACF33ED7239E0FAD2B4A58AA76229A8586E72643F6676989230A41041E9D29628585918252C54B03907D8F1EE2AF5A26EC707F139AB8F6E08391D318AA752DA19AA6FA1970D9C30BEFDC242395099FD4D472DA8651C7E15A4B1807681D69186412697B477B89C15AC605CE9EAF0B0DA3AE68AD864073C741456D1ACEC64E9A39E04A92477041FA1A7B7FC7927FBE47F9FCEA36E94F2C3ECCA99E43B1FD055B3C5BE8C62B154651D1BAD4F37487FDC155EA576DC2319E898FD687B845E961E8E7605FE1CEEAB72F13B7E1FCAA92F4FC2ACBB6E959B39C9ACDAD4DE0F42D42C4BA03D07152EECBB7D4D5585F1327A0229EAF59B475425A1A11365F9F4A50DCD56864C375FE13FCA9DBEB368E98CF42D86F91CFD2A3DF839151893E461EC2A32F52917CE4AEDFBBFF8155577C023D460D3DDFE4C7BD5677AB8C44E63663F220F6FEB4B19C467F3A8657C841EDFD6A453FBBAD521730DBA94F9A79EC3F95449212CA33DE92739949FA5100FDE293EA2ADE88D21AB2C72656FAD5AB788BCCB9FF3C5361877B93EF5B36969961C763DBDAB9A752C7A14A8DC4B487007157FCBCA367BD491DBED0062A52B843F4AE694EECD3D8F2993226D6CD40C3087EB57671CD5472307EB5AC59C738D8AEFC0FA8A2992371456C96873339C3D2928A2BAD1E030A70345143121EA69E0D1454B35892AB54A1A8A2B366F12456A7EFA28A866C9B0DF485E8A28B17CCC8D9EA176A28AA482ECAD23D4B149918A28AD12D069B11C1DD524439A28A523A68B356D31915D1D89418CD14570563DBC332D4B2AFF000E2AACB3000F345158D348BAECCD966193CD5296618EB4515D908A3C9AAD99D7174077A28A2BB6105638652773FFD9'),(3,'0003','Ajenk','Staf','asdadwasdasdwasdasd','ajenksj@yahoo.com','08111',X'FFD8FFE000104A46494600010101006000600000FFDB004300080606070605080707070909080A0C140D0C0B0B0C1912130F141D1A1F1E1D1A1C1C20242E2720222C231C1C2837292C30313434341F27393D38323C2E333432FFDB0043010909090C0B0C180D0D1832211C213232323232323232323232323232323232323232323232323232323232323232323232323232323232323232323232323232FFC00011080038006403012200021101031101FFC4001F0000010501010101010100000000000000000102030405060708090A0BFFC400B5100002010303020403050504040000017D01020300041105122131410613516107227114328191A1082342B1C11552D1F02433627282090A161718191A25262728292A3435363738393A434445464748494A535455565758595A636465666768696A737475767778797A838485868788898A92939495969798999AA2A3A4A5A6A7A8A9AAB2B3B4B5B6B7B8B9BAC2C3C4C5C6C7C8C9CAD2D3D4D5D6D7D8D9DAE1E2E3E4E5E6E7E8E9EAF1F2F3F4F5F6F7F8F9FAFFC4001F0100030101010101010101010000000000000102030405060708090A0BFFC400B51100020102040403040705040400010277000102031104052131061241510761711322328108144291A1B1C109233352F0156272D10A162434E125F11718191A262728292A35363738393A434445464748494A535455565758595A636465666768696A737475767778797A82838485868788898A92939495969798999AA2A3A4A5A6A7A8A9AAB2B3B4B5B6B7B8B9BAC2C3C4C5C6C7C8C9CAD2D3D4D5D6D7D8D9DAE2E3E4E5E6E7E8E9EAF2F3F4F5F6F7F8F9FAFFDA000C03010002110311003F00F3D3AFEA2063CF07EAABFE15674FD56EAFA468E59957038222563F5C7A7F88AD06F08A9FF96D37FDF2BFE3502F873EC97492C53CCAE87703802BAAA62300E2D412BFA7FC0153A5894D73376F5356C21FB4074BCB7B732236D0C8830E300861F5CD4F268D60DD6D61FF00BF6BFE151DAA4D69BB73492927237606D18E83DAAC35DC9FF3C5BF4AF1EACE2E6DC763BE106A2B98A3268561827ECD1FFDF22A8687A1AC9E288248A11E4C726E600703033CFE35B0F75274F21AB47C271837776EC31803F0FF0038AAA327CE95C538A51BD8DFD4F488AFA08CB641070D8EE3FCFF003ACA4B4BAD2633F6079D621CF965495FD6BA0B0BF82FE47862763B5724E318CE783F955EFB34101DCEAA240320F38AEF8A4F5472C9BD99CF69DE28DE0ADCDB95D871BD7BFAF1DABA4B1D42D6E230E928C13D4D73D71047696F792228768CB4BB41C97CF38FE95C3D8F886E6D5CCA232CC79CAC9B40FA0C60534D82836B43DA5D90C39560C18E3839A2BCA13C5A1DC34C6746EBB8F38FC4735A969E2395FF00E3DEFF00CC1FDC66CFFF005E9DC4E27A1515C57FC25376BC1DA7F0A29DD0AC4B2A2F7C55390282715CE4BABDEAB1562A0838231D2B035FD7F53B68A2682609B9886F901FE62B09E5B5A31E6761C331A33972AB9D9CC479F19FAD05D71D457995B788355B99D849745B08E768451D149CF03B6292E754D62DD9526674DCBB949DC370F51CD72FD5E474FB78DAE7A4BC89B4FCC3F3AB7E1101A6BDC1E770FE6D5E40BAC5F3C8035DBA0CF27731C7EB5DFF0081356163A75FDF6A53EC80327CEC3A939E3D4D694E838CAEC99568C9591E97A1E9F1D8178D5D9D9DB2491CFD2B666B765CBBAAB7A82335E6F63E3FFB75C9934EB590F96D8CC88467F11C574D69E34171218AE6DFC899D700E77213DBDFBD74C6718FBA66E1292E62CDFDAC3346E52354900E08E335E6165A6DBDDDBB6C628C8C54E0E45779A8F89EC638668BE7FB5F96405552464F1D7B7E35C568B34697B736E0E338700FEB58D79DBE137A316B56549F48B9872540957FD9EBF95664B1738652AC3AF1822BB822AA5E5BC52C2C648D5881C1C722A29E25FDA349C535A9CB4725F84C47713151D39CD15D0471E102DBD9DC488BC6E8E26619FA81456FED5F639DD2814A656F31FCCFBFB8EEFAF7ACED474F8F50855246650ADBB2B5A6E4B025B2589C927BD552C2BE89A528D99F2D16E2EE8C283463633493ACCA5591D114E0B00460E78F43C55BD3F434BAD2D2F2E0BC8AEA02465885180013F5CE6AC4B12C8F9C804F19207F3AD3D1623FD890DB16DC622549C741807F99AF0B1B4A549B94763DEC1558D54A2F7322DB4CB1F34A35AC7B883B4E338AA9A94AC7478F4F41B634B8691C838073C0E3DAB56EED80999416507A60E2B36343821B939C1AF3E355A773D07493563B3D2B4F1069504B05C20850025D070DEBC7F9E957658AD0472ACB7D148DF795237C9271D000719E9F9D706964F3C4CB12C8C8BCEC0C42FF0085751E1ABFBFD0B4D92486186681FE5432217F9BA9DBCF1D71E9C56B0707AB2B9A4B448B9A85944D731DA5886326DDF2161CAA8E3F3278FC0D4ABE1B8BEC8304C5743E6120EA0FA1F6AAFA66A7716D35D5E4969E6B5C49BD896C118E001C7415B56BE28D26E70D7824B77538D8CA4EEFC57B7E54A51BFC2C154717EF193650EA8F7A2CA5B3791FB4A83E5C7A93D2BA893C3335969AF7B2DB35DB2631046719F7F53F415D1F87DE0D5ADFED36ABB6DD1CA7DDC16231FE35D224059416F2FD830C815AC68C37319D677D0E0AC6C2FDED54DC451C4DFC31ADC18C22F6015781FCE8AEF4D98CFF00AB84FB8414537469BE9F8B23DBD4EE7890D02003E69266FC47F8528D0ED17FE5996FAB1A28A8962EB3FB4CC2386A2BEC8874CB541C5BC7F8AE6A28C468F2C480280A0F038A28AC67394E2F99DCE8A518C66B9518DA805F3F8EA2B1EFFF0072924A0E014DD9F4345158C56A8E96F467516F63FD9FA0DB3A3AEE280B7E2A4E4FE356EC504B691A18C04491B03391C120633D3F0A28AD65A0E0F52719B547425590B12B8ED9ED5931E9CF7B7914710059DBE503B9271451493D4247BCE95A743A46936F650E36C49B491FC47F88FE2735A210EC19EBD80A28AEF3819118A5CF0EABED8CD1451408FFD9'),(9,'012312','Darman','Driver','Jln. Apa Khabar','asdasd@asdas.coasd','081345',X'FFD8FFE000104A46494600010101006000600000FFDB004300080606070605080707070909080A0C140D0C0B0B0C1912130F141D1A1F1E1D1A1C1C20242E2720222C231C1C2837292C30313434341F27393D38323C2E333432FFDB0043010909090C0B0C180D0D1832211C213232323232323232323232323232323232323232323232323232323232323232323232323232323232323232323232323232FFC00011080038006403012200021101031101FFC4001F0000010501010101010100000000000000000102030405060708090A0BFFC400B5100002010303020403050504040000017D01020300041105122131410613516107227114328191A1082342B1C11552D1F02433627282090A161718191A25262728292A3435363738393A434445464748494A535455565758595A636465666768696A737475767778797A838485868788898A92939495969798999AA2A3A4A5A6A7A8A9AAB2B3B4B5B6B7B8B9BAC2C3C4C5C6C7C8C9CAD2D3D4D5D6D7D8D9DAE1E2E3E4E5E6E7E8E9EAF1F2F3F4F5F6F7F8F9FAFFC4001F0100030101010101010101010000000000000102030405060708090A0BFFC400B51100020102040403040705040400010277000102031104052131061241510761711322328108144291A1B1C109233352F0156272D10A162434E125F11718191A262728292A35363738393A434445464748494A535455565758595A636465666768696A737475767778797A82838485868788898A92939495969798999AA2A3A4A5A6A7A8A9AAB2B3B4B5B6B7B8B9BAC2C3C4C5C6C7C8C9CAD2D3D4D5D6D7D8D9DAE2E3E4E5E6E7E8E9EAF2F3F4F5F6F7F8F9FAFFDA000C03010002110311003F00F593D2B0B52DE924928276AFA7D2B6C9E2B0F56702DAF32DB718E71F4AB70E756293B19C975232070EE33D326A63767CB1B891EF4C8CC4BA5C6F2313B46371233D71551981B6663C291B873DAB964AAD2775B1A2E596867788EE261A35DAC6E46539C771DEBCA9F24F35EA1732C66D6659C6F88AE3EA3A62B263F0D68D991AE6668F6B1FBD2851FAD5D194A49B64CD2471BA78FDFBFF00BB5957C3FD3261FED1AEC7508348B7BC58B4CC3304CBB894B83CF4F4EDFA8AE3EF79BD94FF00B46A9FC4714BF8ACADCE29E94DA7AF5AA433D1FC1AC5B47551D44847F5AEBE35C0C9E4F15C67820E34C93FEBA1EFEC2BB446DC8428CF1D4F4AB375B16369A2944648E59BF038A29947504D616AB21486F0AB3039500AF5ED5B59AE7F57936C37441C65D541F4E45520645E72C3A2A4ACBE62EDE4377C9EB504B2ACDA7818D92345B80F4FC87F4A5BB62BA126ECE762E4A0CFF8561FF6F5809D2CD2632CAB0856F97807DCFF008669555FBBBF98E9BFDE24325827B98EE22B78CB48D18007FF00AEB153C1B2B61AF6FE386473C2A8DFF99C8AEA2C352B696EA3B58FCC692727EEAF0028EA4E7A75AAFAD40F03AAE15A0193F28EE4F435E5B956954F6707CABB9D755C2317392BF91836FE0E9ADAE5DE6BB884214FCEA33F9D725E2AD286917B1F972F9B14EBB83FB8EA3F97E75DCC82E6E206B589986F500AE7803DFD2B9BF1769B3699616F23CBE66E631A861F7323248FF3DAA9BA94EBA84E49DFA1CF4A34AB41D44AC7191B3BB840324F000AB9F669E2E5E1751EA578AA5092932329C10783E95D332DEC7087FB7463EA8057649D9911A51926741E0975FB1C8A4FFCB4E3F2AEF21F9941ED8AF24492792DD8C4A2761F2E6388F53F4AF4CD020962D22D9269E591B6827CC18619EC7E95A2D5038A5A1B69CA038ED4522C6BB47038F5A2988D32DA8FFCF2B51FF6D1BFF89AC7D49D85BCC59773971C29EFFA57467A572FAAFCD6EF92769979C0CE7AF6EF574F5B933D2C477EEABA34665573F2AE55793D3DF35CB47E1D6B4BB9268DE33049894E47CEA3AE3A60FE95D26A0DB34E853715E554F273D2A29997ECE8A187CB1A838E07415AD5A77A44D29DAA222B1D32DD66F363897CF847CB215F99770AB521608CA62DF93CEF38EDCD656AB349169BA8491C8C8EB1A0055B0474F7AF3E9AF6EA5C892E66707A8672735E2D7CBDCE7CCA47A3F59515CAD1E9C9249651910E9E841396F9C83FC8D701E36D746AF3436A90B442D9984809072DD38F618FD6AA69934B15EB346ECAC1091B4E3D2B3751732DF4B21182C7279EF554F0AE1539E4EECE4AB8856E48E86779401CD4EBB988DC49FA9A4C53D7AD76A397999D9782CAED9D4903041E6BBFB59136F2C07E35E7BE0B3FBF9C7FB20D7A05B1FE7566B1D8D0475DBF797AFAD14E523068A651B24FCA6B9CBA84DCC1B37606EDD9A28AD28ECC8ABBA2B5F8DB02C44A03904EE154B7C7CA025B3D58D14576A5789C729352D0ADAA847D36E40C0DCA0B64FA1AE3E76D0CB36DB7BECE782ACA07EB4515CD592474D2936AECAD68203A9036CB2AA08CE44B8CE7F0ACCD4C62F1B8EC3FC28A2B964B5329FF0014A78A728E68A2843474DE11729A9322900B21C66BD0ED59C1E403CF634514FA9D11F84BE6465E919E79ED45145319FFD9'),(13,'1234556545654','Elisabeth Hamid','Swasta','Swasta','elish03@gmail.com','08114801020',X'FFD8FFE000104A46494600010101006000600000FFDB004300080606070605080707070909080A0C140D0C0B0B0C1912130F141D1A1F1E1D1A1C1C20242E2720222C231C1C2837292C30313434341F27393D38323C2E333432FFDB0043010909090C0B0C180D0D1832211C213232323232323232323232323232323232323232323232323232323232323232323232323232323232323232323232323232FFC00011080038006403012200021101031101FFC4001F0000010501010101010100000000000000000102030405060708090A0BFFC400B5100002010303020403050504040000017D01020300041105122131410613516107227114328191A1082342B1C11552D1F02433627282090A161718191A25262728292A3435363738393A434445464748494A535455565758595A636465666768696A737475767778797A838485868788898A92939495969798999AA2A3A4A5A6A7A8A9AAB2B3B4B5B6B7B8B9BAC2C3C4C5C6C7C8C9CAD2D3D4D5D6D7D8D9DAE1E2E3E4E5E6E7E8E9EAF1F2F3F4F5F6F7F8F9FAFFC4001F0100030101010101010101010000000000000102030405060708090A0BFFC400B51100020102040403040705040400010277000102031104052131061241510761711322328108144291A1B1C109233352F0156272D10A162434E125F11718191A262728292A35363738393A434445464748494A535455565758595A636465666768696A737475767778797A82838485868788898A92939495969798999AA2A3A4A5A6A7A8A9AAB2B3B4B5B6B7B8B9BAC2C3C4C5C6C7C8C9CAD2D3D4D5D6D7D8D9DAE2E3E4E5E6E7E8E9EAF2F3F4F5F6F7F8F9FAFFDA000C03010002110311003F00E0C014EEB579744BD603841FF02A78D06F3B98C7E27FC2BDBFAD51FE6478AB0D57F94A10CF2DB49E642E51F04647A1E0D36F4DBC92EEB589A38F68CAB1CFCD8E7F5AD13A0DD0FE38FF0033FE1513E8D743F8A2FCCFF8566F11439B9B98D550AB6B58C19E08E51F3A06C742474AA26C84AE96F6E5D6350EC7772474E7F95744FA35D0FE28FF0033FE151C5A74D6F2333ED24A15183EA41FE95C78CA94A71E68C95D1D7858548CB964B4672FFD9A096C3F2A33C8EB4B15ECDA4DE4735B040C130411906AFDC068E490A91C66B3DED4CB227CC141E093DAB86151BDCEE953B6C7A0F84FC60B7909B6D51A38599B11C9D037B1F4A5F16EA12DB3DC436E720C4636C1EE7193F801FCEB9EB0D1ADAE2D6E4412A95817748E4E38F61D4D6BE93E1EBFD76C905BC4C2051B56798E14FF005AB7393D116A096AD983A85888915907C9B403EC6B474FD1B59BED37ED11DABB28FBAC4805C7A807AD7A3D8F836C210AF778B9941CE181D80FD3BFE35B12A2C438C0C7418ABA707CBEF19D49A6F43C631E57C8D13065E082391456EF8BDAD135CDC2458DA48C330F7C919FD28AC9D3772D54563B4163C74A53678ED5D39B00074AAEF683D2B91C995CA734F6BED59F72B1C522A3677B740067FCF5AEA66B7C678AE7F54D4ED2C9CA48DBA403855EB4936C2C65CA9FECB7E5591777112CF2424ED654DC723AD497CBA86AEAC16536F1755543827EA6B3ACB4747D5648C06750020673C02402726AD256D594A12BAD0C49CACB2C847435582E57A57597DA27912328B70150E19B38C9F6AAF73E1CB882169157EE8E45525A1524CDCF87DE0F1AA2B6A57A9BAD49291C47A4841E49F6078FCEBD692DA0B789630A005180ABC01597E184B5B3F0AE9EB14F1F92215DD26E00163CB75E9CE6B623921946629A361EB1B06FEB5DF08A8AB1C92936CA571149F79480BEFF00E35817B25C61FE4DC141C6DEF5D54889D4EE63EA79AE6BC4935CDA5909ACA1591FCC00A6D27703C76F7C55CA4A31BB1420E72515D4F1AD534DD7AFB529A7B8D3673216C7C885801D80228AF5084EA73C4B249A5C08C7B3CD83F960E28AE5FAE61FF98D9E1EA2D34FBD1E8574D0C10BC8EC02A292493590353B69E4895181592232ABE78238FF001AE86EED609A078A486368DD4AB2951820F5AE0FC5908D2B4C66824DA44421B7451828A393CFAFF8570C173348A6ECAFD0D0BABA8155BF7A9C75F985797473D95E5E6A573E6EF9CDC6C8C13F753AF1F539FCAB38EB57E5B2D773B8EEA5CE0D61585D7D92FDD64F977F20D764F0B2A29DF530A5888D4923D0609313448A7E627039EF459ABDDDC5D4B3423CC595A32E3AB735809A9A1651BD43039153D96B72C3A8CDBE54DB190C8AA8AA79E4E48193CFAE6B957C2EE7A1CDEF2B1D7C9A779D6721924E58756C66A3BEB948AC2442D90571590759331C6EE0FBD2348D72C15D805F4F5A94D96CADA75A34D67B24670A092067806AED9FDA34D9D668242AE8720D68C5146B1055205753A17834DCEDBAD4418E0EAB17467FAFA0FD6BA22E537A1849460B53A25859A08D98FCCC80BE3B1C74AC8D76DAE24D2AE96D2430DC7964C6EBD88E4574F28C8DB1AF03B0AA135BB367284FFC0ABD1B26ACCE0678BDBEBB79E57EFAF2EB7E7B515EB0F660371037E045153EC697F2AFB89BCBB9B734EDFDDFD6BCE3C6970F7778900E89D003DE8A2BCAA1FC4475D4F819CC7FC23F679CB44C73FED1AE77C4DE1B6441756519DAA3E75049C7BD1457A4E526B567228456C8E414C88FF789FC6B42C2286E2E9C5CDD3400AE55F19C9A28ACDAD0B8BD4D1BBD46DAC6258AD4F9F2E3058138078E7F9FE75A9A026A1A8C8A8CC2DCC9C465C13B9BB7E068A2B0714ADE66EA726D9EC7E11F0B43A75BADEDFCA97375D8FF00047F41DCFBD75C595B24E368EA5B8028A2BAA31515646729393BB236B88CA7072BEBD07E1DCD56764604843CF71C7F8D1456B133651781F79C28C7D568A28AD2E667FFD9');

#
# Source for table "permintaan"
#

DROP TABLE IF EXISTS `permintaan`;
CREATE TABLE `permintaan` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Kode` varchar(10) NOT NULL DEFAULT '',
  `KaryawanId` int(11) NOT NULL DEFAULT '0',
  `TglPengajuan` date NOT NULL DEFAULT '0000-00-00',
  PRIMARY KEY (`Id`),
  KEY `KaryawanId` (`KaryawanId`),
  CONSTRAINT `Permintaan_Karyawan` FOREIGN KEY (`KaryawanId`) REFERENCES `pelanggan` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=41 DEFAULT CHARSET=latin1;

#
# Data for table "permintaan"
#

INSERT INTO `permintaan` VALUES (41,'MNT-00001',2,'2016-04-05');

#
# Source for table "peminjaman"
#

DROP TABLE IF EXISTS `peminjaman`;
CREATE TABLE `peminjaman` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Kode` varchar(10) NOT NULL DEFAULT '',
  `PermintaanId` int(11) NOT NULL DEFAULT '0',
  `TglMulai` date NOT NULL DEFAULT '0000-00-00',
  `TglKembali` date NOT NULL DEFAULT '0000-00-00',
  `PengambilanKomplet` enum('true','false') NOT NULL DEFAULT 'false',
  `RoleId` int(11) NOT NULL DEFAULT '0',
  PRIMARY KEY (`Id`),
  KEY `PeminjamanDenganPermintaan` (`PermintaanId`),
  CONSTRAINT `PeminjamanDenganPermintaan` FOREIGN KEY (`PermintaanId`) REFERENCES `permintaan` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=36 DEFAULT CHARSET=latin1;

#
# Data for table "peminjaman"
#

INSERT INTO `peminjaman` VALUES (36,'PNJ-00001',41,'2016-04-05','2016-04-08','true',0);

#
# Source for table "setting"
#

DROP TABLE IF EXISTS `setting`;
CREATE TABLE `setting` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `DendaPerHari` double NOT NULL DEFAULT '0',
  `MaxPinjam` int(11) NOT NULL DEFAULT '0',
  `Actived` enum('true','false') NOT NULL DEFAULT 'false',
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;

#
# Data for table "setting"
#

INSERT INTO `setting` VALUES (1,15000,3,'true');

#
# Source for table "tolls"
#

DROP TABLE IF EXISTS `tolls`;
CREATE TABLE `tolls` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Kode` varchar(10) NOT NULL DEFAULT '',
  `KategoriId` int(11) NOT NULL DEFAULT '0',
  `Nama` varchar(255) NOT NULL DEFAULT '',
  `Gambar` blob,
  `Keterangan` tinytext NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `KategoryId` (`KategoriId`),
  CONSTRAINT `KategoryId` FOREIGN KEY (`KategoriId`) REFERENCES `kategori` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=latin1;

#
# Data for table "tolls"
#

INSERT INTO `tolls` VALUES (5,'PKS-0001',1,'Kunci Inggris',X'DFC559980000000049454E44AE426082','Kunci Serbaga Guna');

#
# Source for table "stock"
#

DROP TABLE IF EXISTS `stock`;
CREATE TABLE `stock` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `TollsId` int(11) NOT NULL DEFAULT '0',
  `Jumlah` int(11) NOT NULL DEFAULT '0',
  PRIMARY KEY (`Id`),
  KEY `stockdengantolls` (`TollsId`),
  CONSTRAINT `stockdengantolls` FOREIGN KEY (`TollsId`) REFERENCES `tolls` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=latin1;

#
# Data for table "stock"
#

INSERT INTO `stock` VALUES (7,5,5);

#
# Source for table "permintaan_details"
#

DROP TABLE IF EXISTS `permintaan_details`;
CREATE TABLE `permintaan_details` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `PermintaanID` int(11) NOT NULL DEFAULT '0',
  `TollsId` int(11) NOT NULL DEFAULT '0',
  `StatusTolls` enum('None','Ada','Terpakai','Kosong') NOT NULL DEFAULT 'None',
  PRIMARY KEY (`Id`),
  KEY `PermintaanID` (`PermintaanID`),
  KEY `TollsId` (`TollsId`),
  CONSTRAINT `DetailsDenganPermintaan` FOREIGN KEY (`PermintaanID`) REFERENCES `permintaan` (`Id`),
  CONSTRAINT `PermintaanDetailsDenganTolls` FOREIGN KEY (`TollsId`) REFERENCES `tolls` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=79 DEFAULT CHARSET=latin1;

#
# Data for table "permintaan_details"
#

INSERT INTO `permintaan_details` VALUES (79,41,5,'Ada');

#
# Source for table "peminjaman_details"
#

DROP TABLE IF EXISTS `peminjaman_details`;
CREATE TABLE `peminjaman_details` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `PeminjamanId` int(11) NOT NULL DEFAULT '0',
  `TollsId` int(11) NOT NULL DEFAULT '0',
  `TollsItemId` int(11) NOT NULL DEFAULT '0',
  `TelahKembali` enum('true','false') NOT NULL DEFAULT 'false',
  `SewaId` int(11) NOT NULL DEFAULT '0',
  PRIMARY KEY (`Id`),
  KEY `PeminjamanId` (`PeminjamanId`),
  KEY `TollsId` (`TollsId`),
  CONSTRAINT `DetailsDenganPeminjaman` FOREIGN KEY (`PeminjamanId`) REFERENCES `peminjaman` (`Id`),
  CONSTRAINT `DetailsDenganTolls` FOREIGN KEY (`TollsId`) REFERENCES `tolls` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=43 DEFAULT CHARSET=latin1;

#
# Data for table "peminjaman_details"
#

INSERT INTO `peminjaman_details` VALUES (43,36,5,25,'true',6);

#
# Source for table "transaksi_stock"
#

DROP TABLE IF EXISTS `transaksi_stock`;
CREATE TABLE `transaksi_stock` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Tanggal` date NOT NULL DEFAULT '0000-00-00',
  `TollsId` int(11) NOT NULL DEFAULT '0',
  `Jumlah` int(11) NOT NULL DEFAULT '0',
  `HargaBeli` double NOT NULL DEFAULT '0',
  PRIMARY KEY (`Id`),
  KEY `TollsId` (`TollsId`),
  CONSTRAINT `transaksistockdengantolls` FOREIGN KEY (`TollsId`) REFERENCES `tolls` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=20 DEFAULT CHARSET=latin1;

#
# Data for table "transaksi_stock"
#

INSERT INTO `transaksi_stock` VALUES (24,'2016-04-05',5,5,25000);

#
# Source for table "tollsdetails"
#

DROP TABLE IF EXISTS `tollsdetails`;
CREATE TABLE `tollsdetails` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `TollsId` int(11) NOT NULL DEFAULT '0',
  `TransaksiId` int(11) NOT NULL DEFAULT '0',
  `NomorSeri` varchar(15) NOT NULL DEFAULT '',
  `HargaBeli` double NOT NULL DEFAULT '0',
  `Kondisi` int(3) NOT NULL DEFAULT '100',
  `Status` enum('None','Baik','Hilang','Rusak') NOT NULL DEFAULT 'Baik',
  `StatusDiStok` enum('Kosong','Ada','Terpakai') NOT NULL DEFAULT 'Kosong',
  PRIMARY KEY (`Id`),
  KEY `Transaksi` (`TransaksiId`),
  KEY `Tolls` (`TollsId`),
  CONSTRAINT `Tolls` FOREIGN KEY (`TollsId`) REFERENCES `tolls` (`Id`),
  CONSTRAINT `Transaksi` FOREIGN KEY (`TransaksiId`) REFERENCES `transaksi_stock` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=25 DEFAULT CHARSET=latin1;

#
# Data for table "tollsdetails"
#

INSERT INTO `tollsdetails` VALUES (25,5,24,'PKS-00010001',25000,100,'Baik','Ada'),(26,5,24,'PKS-00010002',25000,100,'Baik','Ada'),(27,5,24,'PKS-00010003',25000,100,'Baik','Ada'),(28,5,24,'PKS-00010004',25000,100,'Baik','Ada'),(29,5,24,'PKS-00010005',25000,100,'Baik','Ada');

#
# Source for table "users"
#

DROP TABLE IF EXISTS `users`;
CREATE TABLE `users` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `UserName` varchar(100) NOT NULL DEFAULT '',
  `PasswordHash` tinytext NOT NULL,
  `AccessLevel` enum('Administrator','Keuangan','Gudang','User') NOT NULL DEFAULT 'Administrator',
  `Activate` enum('true','false') NOT NULL DEFAULT 'false',
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=latin1;

#
# Data for table "users"
#

INSERT INTO `users` VALUES (3,'admin','admin','Administrator','true'),(4,'gudang','gudang','Gudang','true');

#
# Source for table "pengembalian"
#

DROP TABLE IF EXISTS `pengembalian`;
CREATE TABLE `pengembalian` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `peminjamanid` int(11) NOT NULL DEFAULT '0',
  `TglKembali` datetime NOT NULL DEFAULT '0000-00-00 00:00:00',
  `PetugasId` int(11) NOT NULL DEFAULT '0',
  PRIMARY KEY (`Id`),
  KEY `peminjamanid` (`peminjamanid`),
  KEY `PetugasId` (`PetugasId`),
  CONSTRAINT `PengembalianDenganPeminjaman` FOREIGN KEY (`peminjamanid`) REFERENCES `peminjaman` (`Id`),
  CONSTRAINT `pengembaliandenganpetugas` FOREIGN KEY (`PetugasId`) REFERENCES `users` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=latin1;

#
# Data for table "pengembalian"
#

INSERT INTO `pengembalian` VALUES (13,36,'2016-04-05 12:46:46',3);

#
# Source for table "pengembalian_details"
#

DROP TABLE IF EXISTS `pengembalian_details`;
CREATE TABLE `pengembalian_details` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `PengembalianId` int(11) NOT NULL DEFAULT '0',
  `TollsId` int(11) NOT NULL DEFAULT '0',
  `TollsItemId` int(11) NOT NULL DEFAULT '0',
  `KeadaanTolls` enum('Baik','Hilang','Rusak') NOT NULL DEFAULT 'Baik',
  `Keterangan` tinytext NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `PengembalianId` (`PengembalianId`),
  KEY `TollsId` (`TollsId`),
  CONSTRAINT `DetailDenganPengembalian` FOREIGN KEY (`PengembalianId`) REFERENCES `pengembalian` (`Id`),
  CONSTRAINT `PengembalianDetailsDenganTolls` FOREIGN KEY (`TollsId`) REFERENCES `tolls` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=41 DEFAULT CHARSET=latin1;

#
# Data for table "pengembalian_details"
#

INSERT INTO `pengembalian_details` VALUES (41,13,5,25,'Baik','');

#
# Source for table "pelanggaran"
#

DROP TABLE IF EXISTS `pelanggaran`;
CREATE TABLE `pelanggaran` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Kode` varchar(10) NOT NULL DEFAULT '',
  `PeminjamanId` int(11) NOT NULL DEFAULT '0',
  `PengembalianId` int(11) DEFAULT NULL,
  `PetugasId` int(11) NOT NULL DEFAULT '0',
  PRIMARY KEY (`Id`),
  KEY `PeminjamanId` (`PeminjamanId`),
  KEY `PengembalianId` (`PengembalianId`),
  KEY `PetugasId` (`PetugasId`),
  CONSTRAINT `pelanganggarandenganpengembalian` FOREIGN KEY (`PeminjamanId`) REFERENCES `pengembalian` (`Id`),
  CONSTRAINT `pelangarandenganpeminjaman` FOREIGN KEY (`PeminjamanId`) REFERENCES `peminjaman` (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

#
# Data for table "pelanggaran"
#


#
# Source for table "pelanggaran_details"
#

DROP TABLE IF EXISTS `pelanggaran_details`;
CREATE TABLE `pelanggaran_details` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `pelanggaranId` int(11) NOT NULL DEFAULT '0',
  `JenisPelanggaran` enum('Menghilangkan','Merusakkan') NOT NULL DEFAULT 'Merusakkan',
  PRIMARY KEY (`Id`),
  KEY `pelanggaranId` (`pelanggaranId`),
  CONSTRAINT `DetailsDenganPelanggaran` FOREIGN KEY (`pelanggaranId`) REFERENCES `pelanggaran` (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

#
# Data for table "pelanggaran_details"
#


#
# Source for table "denda"
#

DROP TABLE IF EXISTS `denda`;
CREATE TABLE `denda` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Kode` varchar(255) NOT NULL DEFAULT '',
  `KaryawanId` int(11) NOT NULL DEFAULT '0',
  `PelanggaranId` int(11) NOT NULL DEFAULT '0',
  `Tanggal` date NOT NULL DEFAULT '0000-00-00',
  `Selesai` enum('true','false') NOT NULL DEFAULT 'false',
  `Petugas⁯Id` int(11) NOT NULL DEFAULT '0',
  PRIMARY KEY (`Id`),
  KEY `KaryawanId` (`KaryawanId`),
  KEY `PelanggaranId` (`PelanggaranId`),
  KEY `Petugas⁯Id` (`Petugas⁯Id`),
  CONSTRAINT `dendadengankaryawan` FOREIGN KEY (`KaryawanId`) REFERENCES `pelanggan` (`Id`),
  CONSTRAINT `dendadenganpelanggaran` FOREIGN KEY (`KaryawanId`) REFERENCES `pelanggaran` (`Id`),
  CONSTRAINT `DendaDenganPetugas` FOREIGN KEY (`Petugas⁯Id`) REFERENCES `users` (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

#
# Data for table "denda"
#


#
# Source for table "denda_details"
#

DROP TABLE IF EXISTS `denda_details`;
CREATE TABLE `denda_details` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `DendaId` int(11) NOT NULL DEFAULT '0',
  `TollsId` int(11) NOT NULL DEFAULT '0',
  `Nilai` double NOT NULL DEFAULT '0',
  PRIMARY KEY (`Id`),
  KEY `TollsId` (`TollsId`),
  KEY `detailsdengandenda` (`DendaId`),
  CONSTRAINT `detailsdengandenda` FOREIGN KEY (`DendaId`) REFERENCES `denda` (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

#
# Data for table "denda_details"
#

