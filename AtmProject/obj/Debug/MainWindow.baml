   M S B A M L   `   `   `  ����E  AAtmProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:AtmProject
AtmProject  5   	       AtmProject.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:AtmProject     5   	     � Title$  
MainWindow��5   	   $	��350��6   $	��525��6)   .��5	      �  � RowDefinitions 5
   
   �� 5      �� 5       � ColumnDefinitions 5   
   �� 5      �� 5      �� 5      .+�5   
   �� $��0��6   $��	Withdrawl��6    .��64   �� ��6<   �� *WithDrawlAmount+6`   �� 5   
   $��0��6   $��1��6   ��6.   �� *CalculateWithdrawlCommand+.��6\   
Withdraw6f   �� 5   
   $��0��6   $��2��6   ��6.   �� *ClearBinsCommand+.��6S   Clear6Z   �� 5   
   $��1��6   $��0��6    $��Notes��61   .��5      �� ��6   �� *Notes+5      �� 5      $��1��6   $��1��6%   $��Coins ø larger than 20mm��66   .��5      �� ��6   �� *
BigCoins+5      �� 5      $��1��6   $��3��6%   $ ��Coins ø smaller than 20mm��65   .��5      �� ��6   �� *
SmallCoins+5      5$      5%      