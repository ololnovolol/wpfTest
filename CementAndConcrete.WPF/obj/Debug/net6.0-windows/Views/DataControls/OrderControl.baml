   M S B A M L   `   `   `  ????  CementAndConcrete.WPF;    5CementAndConcrete.WPF.Views.DataControls.OrderControl   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .??5      ?? $??Details??6   .??5
   
   ? $??30q?6     ? 	Resources  5      ??%    5       ? ColumnDefinitions 5      ?? 5      $
??Auto ?6#   ?? 5       ? RowDefinitions 5      ?? 5      $
??Auto ?6    ?? 5      $
??Auto ?6    ?? 5      $
??Auto ?6    ?? 5      $
??Auto ?6    ?? 5      $
??Auto ?6    .+?5      ?? $??10q?6   $??0??6$   $??1??64   $??
CustomerId??6A   ???#fff6S   ?? 5      $??10q?6   $??0??6$   $??2??64   $??Total Price??6A   ???#fff6T   ?? 5      $??10q?6   $??0??6$   $??3??64   $??
Start Date??6A   ???#fff6S   ?? 5      $??10q?6   $??0??6$   $??4??64   $??End Date??6A   ???#fff6Q   ?? 5      -   5        $??
CustomerId??5       $??10q?5      $??1??6"   $??1??62    ?? 
IsReadOnly$
 True??5!      ??5"      ?? *(&SelectedListingData.Element.CustomerId+ ?? Mode$ TwoWay=??? 5#      -   5        $??
TotalPrice??5$      $??10q?5#      $??1??6"   $??2??62   ??5%      ?? *(&SelectedListingData.Element.TotalPrice+$ TwoWay=?5&      (  "System.Windows.Controls.DatePicker  5'      -   5        $??	StartDate??5)      $??10q?5'      $??1??6%   $??3??65      SelectedDate 5(      ?? *'%SelectedListingData.Element.StartDate+$ TwoWay=?5)        5*      -   5        $??EndDate??5,      $??10q?5*      $??1??6%   $??4??65    5+      ?? *%#SelectedListingData.Element.EndDate+$ TwoWay=?5,      5.      50      53      