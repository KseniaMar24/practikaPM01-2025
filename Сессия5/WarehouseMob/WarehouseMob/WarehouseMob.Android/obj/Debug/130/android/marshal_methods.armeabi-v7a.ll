; ModuleID = 'obj\Debug\130\android\marshal_methods.armeabi-v7a.ll'
source_filename = "obj\Debug\130\android\marshal_methods.armeabi-v7a.ll"
target datalayout = "e-m:e-p:32:32-Fi8-i64:64-v128:64:128-a:0:32-n32-S64"
target triple = "armv7-unknown-linux-android"


%struct.MonoImage = type opaque

%struct.MonoClass = type opaque

%struct.MarshalMethodsManagedClass = type {
	i32,; uint32_t token
	%struct.MonoClass*; MonoClass* klass
}

%struct.MarshalMethodName = type {
	i64,; uint64_t id
	i8*; char* name
}

%class._JNIEnv = type opaque

%class._jobject = type {
	i8; uint8_t b
}

%class._jclass = type {
	i8; uint8_t b
}

%class._jstring = type {
	i8; uint8_t b
}

%class._jthrowable = type {
	i8; uint8_t b
}

%class._jarray = type {
	i8; uint8_t b
}

%class._jobjectArray = type {
	i8; uint8_t b
}

%class._jbooleanArray = type {
	i8; uint8_t b
}

%class._jbyteArray = type {
	i8; uint8_t b
}

%class._jcharArray = type {
	i8; uint8_t b
}

%class._jshortArray = type {
	i8; uint8_t b
}

%class._jintArray = type {
	i8; uint8_t b
}

%class._jlongArray = type {
	i8; uint8_t b
}

%class._jfloatArray = type {
	i8; uint8_t b
}

%class._jdoubleArray = type {
	i8; uint8_t b
}

; assembly_image_cache
@assembly_image_cache = local_unnamed_addr global [0 x %struct.MonoImage*] zeroinitializer, align 4
; Each entry maps hash of an assembly name to an index into the `assembly_image_cache` array
@assembly_image_cache_hashes = local_unnamed_addr constant [274 x i32] [
	i32 32687329, ; 0: Xamarin.AndroidX.Lifecycle.Runtime => 0x1f2c4e1 => 66
	i32 34715100, ; 1: Xamarin.Google.Guava.ListenableFuture.dll => 0x211b5dc => 100
	i32 57263871, ; 2: Xamarin.Forms.Core.dll => 0x369c6ff => 93
	i32 101534019, ; 3: Xamarin.AndroidX.SlidingPaneLayout => 0x60d4943 => 82
	i32 120558881, ; 4: Xamarin.AndroidX.SlidingPaneLayout.dll => 0x72f9521 => 82
	i32 134690465, ; 5: Xamarin.Kotlin.StdLib.Jdk7.dll => 0x80736a1 => 108
	i32 165246403, ; 6: Xamarin.AndroidX.Collection.dll => 0x9d975c3 => 43
	i32 166922606, ; 7: Xamarin.Android.Support.Compat.dll => 0x9f3096e => 27
	i32 172012715, ; 8: FastAndroidCamera.dll => 0xa40b4ab => 5
	i32 182336117, ; 9: Xamarin.AndroidX.SwipeRefreshLayout.dll => 0xade3a75 => 84
	i32 209399409, ; 10: Xamarin.AndroidX.Browser.dll => 0xc7b2e71 => 41
	i32 212497893, ; 11: Xamarin.Forms.Maps.Android => 0xcaa75e5 => 94
	i32 219130465, ; 12: Xamarin.Android.Support.v4 => 0xd0faa61 => 32
	i32 220171995, ; 13: System.Diagnostics.Debug => 0xd1f8edb => 130
	i32 230216969, ; 14: Xamarin.AndroidX.Legacy.Support.Core.Utils.dll => 0xdb8d509 => 60
	i32 231814094, ; 15: System.Globalization => 0xdd133ce => 136
	i32 232815796, ; 16: System.Web.Services => 0xde07cb4 => 124
	i32 261689757, ; 17: Xamarin.AndroidX.ConstraintLayout.dll => 0xf99119d => 46
	i32 278686392, ; 18: Xamarin.AndroidX.Lifecycle.LiveData.dll => 0x109c6ab8 => 64
	i32 280482487, ; 19: Xamarin.AndroidX.Interpolator => 0x10b7d2b7 => 58
	i32 318968648, ; 20: Xamarin.AndroidX.Activity.dll => 0x13031348 => 33
	i32 319314094, ; 21: Xamarin.Forms.Maps => 0x130858ae => 95
	i32 321597661, ; 22: System.Numerics => 0x132b30dd => 19
	i32 334355562, ; 23: ZXing.Net.Mobile.Forms.dll => 0x13eddc6a => 114
	i32 342366114, ; 24: Xamarin.AndroidX.Lifecycle.Common => 0x146817a2 => 62
	i32 347068432, ; 25: SQLitePCLRaw.lib.e_sqlite3.android.dll => 0x14afd810 => 13
	i32 385762202, ; 26: System.Memory.dll => 0x16fe439a => 18
	i32 389971796, ; 27: Xamarin.Android.Support.Core.UI => 0x173e7f54 => 28
	i32 441335492, ; 28: Xamarin.AndroidX.ConstraintLayout.Core => 0x1a4e3ec4 => 45
	i32 442521989, ; 29: Xamarin.Essentials => 0x1a605985 => 92
	i32 442565967, ; 30: System.Collections => 0x1a61054f => 128
	i32 450948140, ; 31: Xamarin.AndroidX.Fragment.dll => 0x1ae0ec2c => 57
	i32 465846621, ; 32: mscorlib => 0x1bc4415d => 9
	i32 469710990, ; 33: System.dll => 0x1bff388e => 17
	i32 476646585, ; 34: Xamarin.AndroidX.Interpolator.dll => 0x1c690cb9 => 58
	i32 486930444, ; 35: Xamarin.AndroidX.LocalBroadcastManager.dll => 0x1d05f80c => 70
	i32 498788369, ; 36: System.ObjectModel => 0x1dbae811 => 131
	i32 514659665, ; 37: Xamarin.Android.Support.Compat => 0x1ead1551 => 27
	i32 526420162, ; 38: System.Transactions.dll => 0x1f6088c2 => 118
	i32 527452488, ; 39: Xamarin.Kotlin.StdLib.Jdk7 => 0x1f704948 => 108
	i32 545304856, ; 40: System.Runtime.Extensions => 0x2080b118 => 129
	i32 605376203, ; 41: System.IO.Compression.FileSystem => 0x24154ecb => 122
	i32 627609679, ; 42: Xamarin.AndroidX.CustomView => 0x2568904f => 51
	i32 639843206, ; 43: Xamarin.AndroidX.Emoji2.ViewsHelper.dll => 0x26233b86 => 56
	i32 663517072, ; 44: Xamarin.AndroidX.VersionedParcelable => 0x278c7790 => 89
	i32 666292255, ; 45: Xamarin.AndroidX.Arch.Core.Common.dll => 0x27b6d01f => 38
	i32 690569205, ; 46: System.Xml.Linq.dll => 0x29293ff5 => 24
	i32 691348768, ; 47: Xamarin.KotlinX.Coroutines.Android.dll => 0x29352520 => 110
	i32 692692150, ; 48: Xamarin.Android.Support.Annotations => 0x2949a4b6 => 26
	i32 700284507, ; 49: Xamarin.Jetbrains.Annotations => 0x29bd7e5b => 105
	i32 720511267, ; 50: Xamarin.Kotlin.StdLib.Jdk8 => 0x2af22123 => 109
	i32 748832960, ; 51: SQLitePCLRaw.batteries_v2 => 0x2ca248c0 => 11
	i32 775507847, ; 52: System.IO.Compression => 0x2e394f87 => 121
	i32 809851609, ; 53: System.Drawing.Common.dll => 0x30455ad9 => 120
	i32 843511501, ; 54: Xamarin.AndroidX.Print => 0x3246f6cd => 77
	i32 877678880, ; 55: System.Globalization.dll => 0x34505120 => 136
	i32 882883187, ; 56: Xamarin.Android.Support.v4.dll => 0x349fba73 => 32
	i32 928116545, ; 57: Xamarin.Google.Guava.ListenableFuture => 0x3751ef41 => 100
	i32 954320159, ; 58: ZXing.Net.Mobile.Forms => 0x38e1c51f => 114
	i32 956575887, ; 59: Xamarin.Kotlin.StdLib.Jdk8.dll => 0x3904308f => 109
	i32 958213972, ; 60: Xamarin.Android.Support.Media.Compat => 0x391d2f54 => 31
	i32 967690846, ; 61: Xamarin.AndroidX.Lifecycle.Common.dll => 0x39adca5e => 62
	i32 974778368, ; 62: FormsViewGroup.dll => 0x3a19f000 => 6
	i32 992768348, ; 63: System.Collections.dll => 0x3b2c715c => 128
	i32 1012816738, ; 64: Xamarin.AndroidX.SavedState.dll => 0x3c5e5b62 => 81
	i32 1035644815, ; 65: Xamarin.AndroidX.AppCompat => 0x3dbaaf8f => 37
	i32 1042160112, ; 66: Xamarin.Forms.Platform.dll => 0x3e1e19f0 => 97
	i32 1052210849, ; 67: Xamarin.AndroidX.Lifecycle.ViewModel.dll => 0x3eb776a1 => 67
	i32 1084122840, ; 68: Xamarin.Kotlin.StdLib => 0x409e66d8 => 107
	i32 1098259244, ; 69: System => 0x41761b2c => 17
	i32 1134191450, ; 70: ZXingNetMobile.dll => 0x439a635a => 116
	i32 1175144683, ; 71: Xamarin.AndroidX.VectorDrawable.Animated => 0x460b48eb => 87
	i32 1178241025, ; 72: Xamarin.AndroidX.Navigation.Runtime.dll => 0x463a8801 => 74
	i32 1204270330, ; 73: Xamarin.AndroidX.Arch.Core.Common => 0x47c7b4fa => 38
	i32 1264511973, ; 74: Xamarin.AndroidX.Startup.StartupRuntime.dll => 0x4b5eebe5 => 83
	i32 1267360935, ; 75: Xamarin.AndroidX.VectorDrawable => 0x4b8a64a7 => 88
	i32 1275534314, ; 76: Xamarin.KotlinX.Coroutines.Android => 0x4c071bea => 110
	i32 1292207520, ; 77: SQLitePCLRaw.core.dll => 0x4d0585a0 => 12
	i32 1293217323, ; 78: Xamarin.AndroidX.DrawerLayout.dll => 0x4d14ee2b => 53
	i32 1364015309, ; 79: System.IO => 0x514d38cd => 134
	i32 1365406463, ; 80: System.ServiceModel.Internals.dll => 0x516272ff => 125
	i32 1376866003, ; 81: Xamarin.AndroidX.SavedState => 0x52114ed3 => 81
	i32 1395857551, ; 82: Xamarin.AndroidX.Media.dll => 0x5333188f => 71
	i32 1406073936, ; 83: Xamarin.AndroidX.CoordinatorLayout => 0x53cefc50 => 47
	i32 1411638395, ; 84: System.Runtime.CompilerServices.Unsafe => 0x5423e47b => 21
	i32 1445445088, ; 85: Xamarin.Android.Support.Fragment => 0x5627bde0 => 30
	i32 1457743152, ; 86: System.Runtime.Extensions.dll => 0x56e36530 => 129
	i32 1460219004, ; 87: Xamarin.Forms.Xaml => 0x57092c7c => 98
	i32 1462112819, ; 88: System.IO.Compression.dll => 0x57261233 => 121
	i32 1469204771, ; 89: Xamarin.AndroidX.AppCompat.AppCompatResources => 0x57924923 => 36
	i32 1530663695, ; 90: Xamarin.Forms.Maps.dll => 0x5b3c130f => 95
	i32 1543031311, ; 91: System.Text.RegularExpressions.dll => 0x5bf8ca0f => 135
	i32 1571005899, ; 92: zxing.portable => 0x5da3a5cb => 115
	i32 1574652163, ; 93: Xamarin.Android.Support.Core.Utils.dll => 0x5ddb4903 => 29
	i32 1582372066, ; 94: Xamarin.AndroidX.DocumentFile.dll => 0x5e5114e2 => 52
	i32 1592978981, ; 95: System.Runtime.Serialization.dll => 0x5ef2ee25 => 3
	i32 1622152042, ; 96: Xamarin.AndroidX.Loader.dll => 0x60b0136a => 69
	i32 1624863272, ; 97: Xamarin.AndroidX.ViewPager2 => 0x60d97228 => 91
	i32 1635184631, ; 98: Xamarin.AndroidX.Emoji2.ViewsHelper => 0x6176eff7 => 56
	i32 1636350590, ; 99: Xamarin.AndroidX.CursorAdapter => 0x6188ba7e => 50
	i32 1639515021, ; 100: System.Net.Http.dll => 0x61b9038d => 2
	i32 1639986890, ; 101: System.Text.RegularExpressions => 0x61c036ca => 135
	i32 1657153582, ; 102: System.Runtime => 0x62c6282e => 22
	i32 1658241508, ; 103: Xamarin.AndroidX.Tracing.Tracing.dll => 0x62d6c1e4 => 85
	i32 1658251792, ; 104: Xamarin.Google.Android.Material.dll => 0x62d6ea10 => 99
	i32 1670060433, ; 105: Xamarin.AndroidX.ConstraintLayout => 0x638b1991 => 46
	i32 1698840827, ; 106: Xamarin.Kotlin.StdLib.Common => 0x654240fb => 106
	i32 1701541528, ; 107: System.Diagnostics.Debug.dll => 0x656b7698 => 130
	i32 1711441057, ; 108: SQLitePCLRaw.lib.e_sqlite3.android => 0x660284a1 => 13
	i32 1729485958, ; 109: Xamarin.AndroidX.CardView.dll => 0x6715dc86 => 42
	i32 1766324549, ; 110: Xamarin.AndroidX.SwipeRefreshLayout => 0x6947f945 => 84
	i32 1776026572, ; 111: System.Core.dll => 0x69dc03cc => 16
	i32 1788241197, ; 112: Xamarin.AndroidX.Fragment => 0x6a96652d => 57
	i32 1808609942, ; 113: Xamarin.AndroidX.Loader => 0x6bcd3296 => 69
	i32 1813058853, ; 114: Xamarin.Kotlin.StdLib.dll => 0x6c111525 => 107
	i32 1813201214, ; 115: Xamarin.Google.Android.Material => 0x6c13413e => 99
	i32 1818569960, ; 116: Xamarin.AndroidX.Navigation.UI.dll => 0x6c652ce8 => 75
	i32 1867746548, ; 117: Xamarin.Essentials.dll => 0x6f538cf4 => 92
	i32 1878053835, ; 118: Xamarin.Forms.Xaml.dll => 0x6ff0d3cb => 98
	i32 1881862856, ; 119: Xamarin.Forms.Maps.Android.dll => 0x702af2c8 => 94
	i32 1885316902, ; 120: Xamarin.AndroidX.Arch.Core.Runtime.dll => 0x705fa726 => 39
	i32 1904184254, ; 121: FastAndroidCamera => 0x717f8bbe => 5
	i32 1908813208, ; 122: Xamarin.GooglePlayServices.Basement => 0x71c62d98 => 102
	i32 1919157823, ; 123: Xamarin.AndroidX.MultiDex.dll => 0x7264063f => 72
	i32 1970135796, ; 124: WarehouseMob.Android.dll => 0x756de2f4 => 0
	i32 1983156543, ; 125: Xamarin.Kotlin.StdLib.Common.dll => 0x7634913f => 106
	i32 2011961780, ; 126: System.Buffers.dll => 0x77ec19b4 => 15
	i32 2019465201, ; 127: Xamarin.AndroidX.Lifecycle.ViewModel => 0x785e97f1 => 67
	i32 2055257422, ; 128: Xamarin.AndroidX.Lifecycle.LiveData.Core.dll => 0x7a80bd4e => 63
	i32 2079903147, ; 129: System.Runtime.dll => 0x7bf8cdab => 22
	i32 2090596640, ; 130: System.Numerics.Vectors => 0x7c9bf920 => 20
	i32 2097448633, ; 131: Xamarin.AndroidX.Legacy.Support.Core.UI => 0x7d0486b9 => 59
	i32 2103459038, ; 132: SQLitePCLRaw.provider.e_sqlite3.dll => 0x7d603cde => 14
	i32 2126786730, ; 133: Xamarin.Forms.Platform.Android => 0x7ec430aa => 96
	i32 2129483829, ; 134: Xamarin.GooglePlayServices.Base.dll => 0x7eed5835 => 101
	i32 2166116741, ; 135: Xamarin.Android.Support.Core.Utils => 0x811c5185 => 29
	i32 2193016926, ; 136: System.ObjectModel.dll => 0x82b6c85e => 131
	i32 2201107256, ; 137: Xamarin.KotlinX.Coroutines.Core.Jvm.dll => 0x83323b38 => 111
	i32 2201231467, ; 138: System.Net.Http => 0x8334206b => 2
	i32 2217644978, ; 139: Xamarin.AndroidX.VectorDrawable.Animated.dll => 0x842e93b2 => 87
	i32 2244775296, ; 140: Xamarin.AndroidX.LocalBroadcastManager => 0x85cc8d80 => 70
	i32 2256548716, ; 141: Xamarin.AndroidX.MultiDex => 0x8680336c => 72
	i32 2261435625, ; 142: Xamarin.AndroidX.Legacy.Support.V4.dll => 0x86cac4e9 => 61
	i32 2279755925, ; 143: Xamarin.AndroidX.RecyclerView.dll => 0x87e25095 => 79
	i32 2315684594, ; 144: Xamarin.AndroidX.Annotation.dll => 0x8a068af2 => 34
	i32 2329204181, ; 145: zxing.portable.dll => 0x8ad4d5d5 => 115
	i32 2330457430, ; 146: Xamarin.Android.Support.Core.UI.dll => 0x8ae7f556 => 28
	i32 2341995103, ; 147: ZXingNetMobile => 0x8b98025f => 116
	i32 2373288475, ; 148: Xamarin.Android.Support.Fragment.dll => 0x8d75821b => 30
	i32 2403452196, ; 149: Xamarin.AndroidX.Emoji2.dll => 0x8f41c524 => 55
	i32 2409053734, ; 150: Xamarin.AndroidX.Preference.dll => 0x8f973e26 => 76
	i32 2431243866, ; 151: ZXing.Net.Mobile.Core.dll => 0x90e9d65a => 112
	i32 2454381212, ; 152: WarehouseMob => 0x924ae29c => 25
	i32 2454642406, ; 153: System.Text.Encoding.dll => 0x924edee6 => 133
	i32 2465273461, ; 154: SQLitePCLRaw.batteries_v2.dll => 0x92f11675 => 11
	i32 2465532216, ; 155: Xamarin.AndroidX.ConstraintLayout.Core.dll => 0x92f50938 => 45
	i32 2471841756, ; 156: netstandard.dll => 0x93554fdc => 1
	i32 2475788418, ; 157: Java.Interop.dll => 0x93918882 => 7
	i32 2482213323, ; 158: ZXing.Net.Mobile.Forms.Android => 0x93f391cb => 113
	i32 2501346920, ; 159: System.Data.DataSetExtensions => 0x95178668 => 119
	i32 2505896520, ; 160: Xamarin.AndroidX.Lifecycle.Runtime.dll => 0x955cf248 => 66
	i32 2581819634, ; 161: Xamarin.AndroidX.VectorDrawable.dll => 0x99e370f2 => 88
	i32 2605712449, ; 162: Xamarin.KotlinX.Coroutines.Core.Jvm => 0x9b500441 => 111
	i32 2620871830, ; 163: Xamarin.AndroidX.CursorAdapter.dll => 0x9c375496 => 50
	i32 2624644809, ; 164: Xamarin.AndroidX.DynamicAnimation => 0x9c70e6c9 => 54
	i32 2633051222, ; 165: Xamarin.AndroidX.Lifecycle.LiveData => 0x9cf12c56 => 64
	i32 2693849962, ; 166: System.IO.dll => 0xa090e36a => 134
	i32 2701096212, ; 167: Xamarin.AndroidX.Tracing.Tracing => 0xa0ff7514 => 85
	i32 2715334215, ; 168: System.Threading.Tasks.dll => 0xa1d8b647 => 127
	i32 2732626843, ; 169: Xamarin.AndroidX.Activity => 0xa2e0939b => 33
	i32 2737747696, ; 170: Xamarin.AndroidX.AppCompat.AppCompatResources.dll => 0xa32eb6f0 => 36
	i32 2766581644, ; 171: Xamarin.Forms.Core => 0xa4e6af8c => 93
	i32 2770495804, ; 172: Xamarin.Jetbrains.Annotations.dll => 0xa522693c => 105
	i32 2778768386, ; 173: Xamarin.AndroidX.ViewPager.dll => 0xa5a0a402 => 90
	i32 2779977773, ; 174: Xamarin.AndroidX.ResourceInspection.Annotation.dll => 0xa5b3182d => 80
	i32 2810250172, ; 175: Xamarin.AndroidX.CoordinatorLayout.dll => 0xa78103bc => 47
	i32 2819470561, ; 176: System.Xml.dll => 0xa80db4e1 => 23
	i32 2821294376, ; 177: Xamarin.AndroidX.ResourceInspection.Annotation => 0xa8298928 => 80
	i32 2847418871, ; 178: Xamarin.GooglePlayServices.Base => 0xa9b829f7 => 101
	i32 2853208004, ; 179: Xamarin.AndroidX.ViewPager => 0xaa107fc4 => 90
	i32 2855708567, ; 180: Xamarin.AndroidX.Transition => 0xaa36a797 => 86
	i32 2903344695, ; 181: System.ComponentModel.Composition => 0xad0d8637 => 123
	i32 2905242038, ; 182: mscorlib.dll => 0xad2a79b6 => 9
	i32 2916838712, ; 183: Xamarin.AndroidX.ViewPager2.dll => 0xaddb6d38 => 91
	i32 2919462931, ; 184: System.Numerics.Vectors.dll => 0xae037813 => 20
	i32 2921128767, ; 185: Xamarin.AndroidX.Annotation.Experimental.dll => 0xae1ce33f => 35
	i32 2970759306, ; 186: BCrypt.Net-Next.dll => 0xb112308a => 4
	i32 2978675010, ; 187: Xamarin.AndroidX.DrawerLayout => 0xb18af942 => 53
	i32 2996846495, ; 188: Xamarin.AndroidX.Lifecycle.Process.dll => 0xb2a03f9f => 65
	i32 3016983068, ; 189: Xamarin.AndroidX.Startup.StartupRuntime => 0xb3d3821c => 83
	i32 3017076677, ; 190: Xamarin.GooglePlayServices.Maps => 0xb3d4efc5 => 103
	i32 3024354802, ; 191: Xamarin.AndroidX.Legacy.Support.Core.Utils => 0xb443fdf2 => 60
	i32 3044182254, ; 192: FormsViewGroup => 0xb57288ee => 6
	i32 3057625584, ; 193: Xamarin.AndroidX.Navigation.Common => 0xb63fa9f0 => 73
	i32 3058099980, ; 194: Xamarin.GooglePlayServices.Tasks => 0xb646e70c => 104
	i32 3075834255, ; 195: System.Threading.Tasks => 0xb755818f => 127
	i32 3092211740, ; 196: Xamarin.Android.Support.Media.Compat.dll => 0xb84f681c => 31
	i32 3111772706, ; 197: System.Runtime.Serialization => 0xb979e222 => 3
	i32 3204380047, ; 198: System.Data.dll => 0xbefef58f => 117
	i32 3211777861, ; 199: Xamarin.AndroidX.DocumentFile => 0xbf6fd745 => 52
	i32 3220365878, ; 200: System.Threading => 0xbff2e236 => 132
	i32 3230466174, ; 201: Xamarin.GooglePlayServices.Basement.dll => 0xc08d007e => 102
	i32 3247949154, ; 202: Mono.Security => 0xc197c562 => 126
	i32 3258312781, ; 203: Xamarin.AndroidX.CardView => 0xc235e84d => 42
	i32 3267021929, ; 204: Xamarin.AndroidX.AsyncLayoutInflater => 0xc2bacc69 => 40
	i32 3286872994, ; 205: SQLite-net.dll => 0xc3e9b3a2 => 10
	i32 3299363146, ; 206: System.Text.Encoding => 0xc4a8494a => 133
	i32 3317135071, ; 207: Xamarin.AndroidX.CustomView.dll => 0xc5b776df => 51
	i32 3317144872, ; 208: System.Data => 0xc5b79d28 => 117
	i32 3340431453, ; 209: Xamarin.AndroidX.Arch.Core.Runtime => 0xc71af05d => 39
	i32 3345895724, ; 210: Xamarin.AndroidX.ProfileInstaller.ProfileInstaller.dll => 0xc76e512c => 78
	i32 3346324047, ; 211: Xamarin.AndroidX.Navigation.Runtime => 0xc774da4f => 74
	i32 3352104953, ; 212: WarehouseMob.dll => 0xc7cd0ff9 => 25
	i32 3353484488, ; 213: Xamarin.AndroidX.Legacy.Support.Core.UI.dll => 0xc7e21cc8 => 59
	i32 3360279109, ; 214: SQLitePCLRaw.core => 0xc849ca45 => 12
	i32 3362522851, ; 215: Xamarin.AndroidX.Core => 0xc86c06e3 => 49
	i32 3366347497, ; 216: Java.Interop => 0xc8a662e9 => 7
	i32 3374999561, ; 217: Xamarin.AndroidX.RecyclerView => 0xc92a6809 => 79
	i32 3395150330, ; 218: System.Runtime.CompilerServices.Unsafe.dll => 0xca5de1fa => 21
	i32 3404865022, ; 219: System.ServiceModel.Internals => 0xcaf21dfe => 125
	i32 3429136800, ; 220: System.Xml => 0xcc6479a0 => 23
	i32 3430777524, ; 221: netstandard => 0xcc7d82b4 => 1
	i32 3439690031, ; 222: Xamarin.Android.Support.Annotations.dll => 0xcd05812f => 26
	i32 3441283291, ; 223: Xamarin.AndroidX.DynamicAnimation.dll => 0xcd1dd0db => 54
	i32 3472012038, ; 224: BCrypt.Net-Next => 0xcef2b306 => 4
	i32 3476120550, ; 225: Mono.Android => 0xcf3163e6 => 8
	i32 3486566296, ; 226: System.Transactions => 0xcfd0c798 => 118
	i32 3493954962, ; 227: Xamarin.AndroidX.Concurrent.Futures.dll => 0xd0418592 => 44
	i32 3501239056, ; 228: Xamarin.AndroidX.AsyncLayoutInflater.dll => 0xd0b0ab10 => 40
	i32 3509114376, ; 229: System.Xml.Linq => 0xd128d608 => 24
	i32 3536029504, ; 230: Xamarin.Forms.Platform.Android.dll => 0xd2c38740 => 96
	i32 3567349600, ; 231: System.ComponentModel.Composition.dll => 0xd4a16f60 => 123
	i32 3618140916, ; 232: Xamarin.AndroidX.Preference => 0xd7a872f4 => 76
	i32 3627220390, ; 233: Xamarin.AndroidX.Print.dll => 0xd832fda6 => 77
	i32 3632359727, ; 234: Xamarin.Forms.Platform => 0xd881692f => 97
	i32 3633644679, ; 235: Xamarin.AndroidX.Annotation.Experimental => 0xd8950487 => 35
	i32 3641597786, ; 236: Xamarin.AndroidX.Lifecycle.LiveData.Core => 0xd90e5f5a => 63
	i32 3672681054, ; 237: Mono.Android.dll => 0xdae8aa5e => 8
	i32 3676310014, ; 238: System.Web.Services.dll => 0xdb2009fe => 124
	i32 3682565725, ; 239: Xamarin.AndroidX.Browser => 0xdb7f7e5d => 41
	i32 3684561358, ; 240: Xamarin.AndroidX.Concurrent.Futures => 0xdb9df1ce => 44
	i32 3689375977, ; 241: System.Drawing.Common => 0xdbe768e9 => 120
	i32 3706696989, ; 242: Xamarin.AndroidX.Core.Core.Ktx.dll => 0xdcefb51d => 48
	i32 3718780102, ; 243: Xamarin.AndroidX.Annotation => 0xdda814c6 => 34
	i32 3724971120, ; 244: Xamarin.AndroidX.Navigation.Common.dll => 0xde068c70 => 73
	i32 3754567612, ; 245: SQLitePCLRaw.provider.e_sqlite3 => 0xdfca27bc => 14
	i32 3758932259, ; 246: Xamarin.AndroidX.Legacy.Support.V4 => 0xe00cc123 => 61
	i32 3786282454, ; 247: Xamarin.AndroidX.Collection => 0xe1ae15d6 => 43
	i32 3822602673, ; 248: Xamarin.AndroidX.Media => 0xe3d849b1 => 71
	i32 3829621856, ; 249: System.Numerics.dll => 0xe4436460 => 19
	i32 3847036339, ; 250: ZXing.Net.Mobile.Forms.Android.dll => 0xe54d1db3 => 113
	i32 3857872905, ; 251: WarehouseMob.Android => 0xe5f27809 => 0
	i32 3876362041, ; 252: SQLite-net => 0xe70c9739 => 10
	i32 3885922214, ; 253: Xamarin.AndroidX.Transition.dll => 0xe79e77a6 => 86
	i32 3888767677, ; 254: Xamarin.AndroidX.ProfileInstaller.ProfileInstaller => 0xe7c9e2bd => 78
	i32 3896760992, ; 255: Xamarin.AndroidX.Core.dll => 0xe843daa0 => 49
	i32 3920810846, ; 256: System.IO.Compression.FileSystem.dll => 0xe9b2d35e => 122
	i32 3921031405, ; 257: Xamarin.AndroidX.VersionedParcelable.dll => 0xe9b630ed => 89
	i32 3931092270, ; 258: Xamarin.AndroidX.Navigation.UI => 0xea4fb52e => 75
	i32 3945713374, ; 259: System.Data.DataSetExtensions.dll => 0xeb2ecede => 119
	i32 3955647286, ; 260: Xamarin.AndroidX.AppCompat.dll => 0xebc66336 => 37
	i32 3959773229, ; 261: Xamarin.AndroidX.Lifecycle.Process => 0xec05582d => 65
	i32 3970018735, ; 262: Xamarin.GooglePlayServices.Tasks.dll => 0xeca1adaf => 104
	i32 4025784931, ; 263: System.Memory => 0xeff49a63 => 18
	i32 4073602200, ; 264: System.Threading.dll => 0xf2ce3c98 => 132
	i32 4101593132, ; 265: Xamarin.AndroidX.Emoji2 => 0xf479582c => 55
	i32 4105002889, ; 266: Mono.Security.dll => 0xf4ad5f89 => 126
	i32 4151237749, ; 267: System.Core => 0xf76edc75 => 16
	i32 4182413190, ; 268: Xamarin.AndroidX.Lifecycle.ViewModelSavedState.dll => 0xf94a8f86 => 68
	i32 4186595366, ; 269: ZXing.Net.Mobile.Core => 0xf98a6026 => 112
	i32 4256097574, ; 270: Xamarin.AndroidX.Core.Core.Ktx => 0xfdaee526 => 48
	i32 4260525087, ; 271: System.Buffers => 0xfdf2741f => 15
	i32 4278134329, ; 272: Xamarin.GooglePlayServices.Maps.dll => 0xfeff2639 => 103
	i32 4292120959 ; 273: Xamarin.AndroidX.Lifecycle.ViewModelSavedState => 0xffd4917f => 68
], align 4
@assembly_image_cache_indices = local_unnamed_addr constant [274 x i32] [
	i32 66, i32 100, i32 93, i32 82, i32 82, i32 108, i32 43, i32 27, ; 0..7
	i32 5, i32 84, i32 41, i32 94, i32 32, i32 130, i32 60, i32 136, ; 8..15
	i32 124, i32 46, i32 64, i32 58, i32 33, i32 95, i32 19, i32 114, ; 16..23
	i32 62, i32 13, i32 18, i32 28, i32 45, i32 92, i32 128, i32 57, ; 24..31
	i32 9, i32 17, i32 58, i32 70, i32 131, i32 27, i32 118, i32 108, ; 32..39
	i32 129, i32 122, i32 51, i32 56, i32 89, i32 38, i32 24, i32 110, ; 40..47
	i32 26, i32 105, i32 109, i32 11, i32 121, i32 120, i32 77, i32 136, ; 48..55
	i32 32, i32 100, i32 114, i32 109, i32 31, i32 62, i32 6, i32 128, ; 56..63
	i32 81, i32 37, i32 97, i32 67, i32 107, i32 17, i32 116, i32 87, ; 64..71
	i32 74, i32 38, i32 83, i32 88, i32 110, i32 12, i32 53, i32 134, ; 72..79
	i32 125, i32 81, i32 71, i32 47, i32 21, i32 30, i32 129, i32 98, ; 80..87
	i32 121, i32 36, i32 95, i32 135, i32 115, i32 29, i32 52, i32 3, ; 88..95
	i32 69, i32 91, i32 56, i32 50, i32 2, i32 135, i32 22, i32 85, ; 96..103
	i32 99, i32 46, i32 106, i32 130, i32 13, i32 42, i32 84, i32 16, ; 104..111
	i32 57, i32 69, i32 107, i32 99, i32 75, i32 92, i32 98, i32 94, ; 112..119
	i32 39, i32 5, i32 102, i32 72, i32 0, i32 106, i32 15, i32 67, ; 120..127
	i32 63, i32 22, i32 20, i32 59, i32 14, i32 96, i32 101, i32 29, ; 128..135
	i32 131, i32 111, i32 2, i32 87, i32 70, i32 72, i32 61, i32 79, ; 136..143
	i32 34, i32 115, i32 28, i32 116, i32 30, i32 55, i32 76, i32 112, ; 144..151
	i32 25, i32 133, i32 11, i32 45, i32 1, i32 7, i32 113, i32 119, ; 152..159
	i32 66, i32 88, i32 111, i32 50, i32 54, i32 64, i32 134, i32 85, ; 160..167
	i32 127, i32 33, i32 36, i32 93, i32 105, i32 90, i32 80, i32 47, ; 168..175
	i32 23, i32 80, i32 101, i32 90, i32 86, i32 123, i32 9, i32 91, ; 176..183
	i32 20, i32 35, i32 4, i32 53, i32 65, i32 83, i32 103, i32 60, ; 184..191
	i32 6, i32 73, i32 104, i32 127, i32 31, i32 3, i32 117, i32 52, ; 192..199
	i32 132, i32 102, i32 126, i32 42, i32 40, i32 10, i32 133, i32 51, ; 200..207
	i32 117, i32 39, i32 78, i32 74, i32 25, i32 59, i32 12, i32 49, ; 208..215
	i32 7, i32 79, i32 21, i32 125, i32 23, i32 1, i32 26, i32 54, ; 216..223
	i32 4, i32 8, i32 118, i32 44, i32 40, i32 24, i32 96, i32 123, ; 224..231
	i32 76, i32 77, i32 97, i32 35, i32 63, i32 8, i32 124, i32 41, ; 232..239
	i32 44, i32 120, i32 48, i32 34, i32 73, i32 14, i32 61, i32 43, ; 240..247
	i32 71, i32 19, i32 113, i32 0, i32 10, i32 86, i32 78, i32 49, ; 248..255
	i32 122, i32 89, i32 75, i32 119, i32 37, i32 65, i32 104, i32 18, ; 256..263
	i32 132, i32 55, i32 126, i32 16, i32 68, i32 112, i32 48, i32 15, ; 264..271
	i32 103, i32 68 ; 272..273
], align 4

@marshal_methods_number_of_classes = local_unnamed_addr constant i32 0, align 4

; marshal_methods_class_cache
@marshal_methods_class_cache = global [0 x %struct.MarshalMethodsManagedClass] [
], align 4; end of 'marshal_methods_class_cache' array


@get_function_pointer = internal unnamed_addr global void (i32, i32, i32, i8**)* null, align 4

; Function attributes: "frame-pointer"="all" "min-legal-vector-width"="0" mustprogress nofree norecurse nosync "no-trapping-math"="true" nounwind sspstrong "stack-protector-buffer-size"="8" "target-cpu"="generic" "target-features"="+armv7-a,+d32,+dsp,+fp64,+neon,+thumb-mode,+vfp2,+vfp2sp,+vfp3,+vfp3d16,+vfp3d16sp,+vfp3sp,-aes,-fp-armv8,-fp-armv8d16,-fp-armv8d16sp,-fp-armv8sp,-fp16,-fp16fml,-fullfp16,-sha2,-vfp4,-vfp4d16,-vfp4d16sp,-vfp4sp" uwtable willreturn writeonly
define void @xamarin_app_init (void (i32, i32, i32, i8**)* %fn) local_unnamed_addr #0
{
	store void (i32, i32, i32, i8**)* %fn, void (i32, i32, i32, i8**)** @get_function_pointer, align 4
	ret void
}

; Names of classes in which marshal methods reside
@mm_class_names = local_unnamed_addr constant [0 x i8*] zeroinitializer, align 4
@__MarshalMethodName_name.0 = internal constant [1 x i8] c"\00", align 1

; mm_method_names
@mm_method_names = local_unnamed_addr constant [1 x %struct.MarshalMethodName] [
	; 0
	%struct.MarshalMethodName {
		i64 0, ; id 0x0; name: 
		i8* getelementptr inbounds ([1 x i8], [1 x i8]* @__MarshalMethodName_name.0, i32 0, i32 0); name
	}
], align 8; end of 'mm_method_names' array


attributes #0 = { "min-legal-vector-width"="0" mustprogress nofree norecurse nosync "no-trapping-math"="true" nounwind sspstrong "stack-protector-buffer-size"="8" uwtable willreturn writeonly "frame-pointer"="all" "target-cpu"="generic" "target-features"="+armv7-a,+d32,+dsp,+fp64,+neon,+thumb-mode,+vfp2,+vfp2sp,+vfp3,+vfp3d16,+vfp3d16sp,+vfp3sp,-aes,-fp-armv8,-fp-armv8d16,-fp-armv8d16sp,-fp-armv8sp,-fp16,-fp16fml,-fullfp16,-sha2,-vfp4,-vfp4d16,-vfp4d16sp,-vfp4sp" }
attributes #1 = { "min-legal-vector-width"="0" mustprogress "no-trapping-math"="true" nounwind sspstrong "stack-protector-buffer-size"="8" uwtable "frame-pointer"="all" "target-cpu"="generic" "target-features"="+armv7-a,+d32,+dsp,+fp64,+neon,+thumb-mode,+vfp2,+vfp2sp,+vfp3,+vfp3d16,+vfp3d16sp,+vfp3sp,-aes,-fp-armv8,-fp-armv8d16,-fp-armv8d16sp,-fp-armv8sp,-fp16,-fp16fml,-fullfp16,-sha2,-vfp4,-vfp4d16,-vfp4d16sp,-vfp4sp" }
attributes #2 = { nounwind }

!llvm.module.flags = !{!0, !1, !2}
!llvm.ident = !{!3}
!0 = !{i32 1, !"wchar_size", i32 4}
!1 = !{i32 7, !"PIC Level", i32 2}
!2 = !{i32 1, !"min_enum_size", i32 4}
!3 = !{!"Xamarin.Android remotes/origin/d17-5 @ 45b0e144f73b2c8747d8b5ec8cbd3b55beca67f0"}
!llvm.linker.options = !{}
