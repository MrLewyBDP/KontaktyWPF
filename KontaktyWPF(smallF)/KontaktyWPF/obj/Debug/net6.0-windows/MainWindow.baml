   M S B A M L   `   `   `  ????F  BKontaktyWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:KontaktyWPFKontaktyWPF  5   	       KontaktyWPF.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:KontaktyWPF     5   	   -   5          ? Title$  
MainWindow??5   	   $	??461??6   $	??982??6)   .??5	      ? .+?5
   
   o? $??2,10,-1,378q?6   .@?5      m? $
??Plik??6   .@?5      m? -   5        $
??Nowy??5      6<   m? 5      -   5        $??Zakończ??5      6;   5      m? 5      $??Edytuj??6   .@?5      m? -   5        $??Nowy Kontakt??5      6H   m? 5      -   5        $??Usun Kontakt??5      6G   m? 5      -   5        $??Edytuj Kontakt??5      6K   5      5      &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ DataGridList??5      $??18,183,18,101q?6*      ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$	 115 6A   $	??946??6S    ? ContextMenu 5      ?? 5      .@?5      m? -   5        $??Usun Kontakt??5      65   m? 5      -	   5        $??Edytuj Kontakt??5      67   5       ? 	Resources 5      ??%    5       5!      ?? 5#   
   $??	Wyszukaj:??6   $
??Left=?6$   $??304,152,0,0q?6?   $	??Top=?6T   $??26??6l    J? RenderTransformOrigin$ 0.662,0.194&?6x   ?? 5$   
   -
   5         ??Name$
 wysz??5$      $
??Left=?6    $??390,157,0,0q?6V    ?? TextWrapping$
 Wrap=?6k   $	??Top=?6   $	??276??6?   $??18??6?   ? 5%   
   -   5         ?Name$ ProgressBar??5%      $??Center=?6+   $??22??6H   $??	0,348,0,0q?6T   $	??Top=?6g   $	??946??6   ?? 5&   
   -   5        $??<??5&      $
??Left=?6    $??	8,375,0,0q?6;   $	??Top=?6N   $ 0,0.002&?6s   $??62??6?   $??22??6?   ?? 5'   
   -   5        $??>??5'      $
??Left=?6    $??898,375,0,0q?6;   $	??Top=?6P   $ 0,0.002&?6v   $??60??6?   $??22??6?   ?? 5(   
   -   5        	 ??Name$	 NumerStrony??5(      $??1??6%   $??Center=?61   $??	0,377,0,0q?6N   $	??Top=?6a   $??28??6y   ?? 5)   
   $??Aktualna Baza:??6   $
??Left=?6)   $??412,111,0,0q?6D   $	??Top=?6Y   $??26??6q   ?? 5*   
   -   5        $	 AkBaz??5*      $?? ??6   $
??Left=?6*   $??523,111,0,0q?6E   $	??Top=?6Z   5,      5-      