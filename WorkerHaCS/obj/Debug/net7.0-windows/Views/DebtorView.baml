   M S B A M L   `   `   `  ����E  AWorkerHaCS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:WorkerHaCS.ViewsWorkerHaCS.Views  5   	   =#clr-namespace:WorkerHaCS.ConvertersWorkerHaCS.Converters  5   	   !    WorkerHaCS.Views.DebtorView   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:WorkerHaCS.Views     5   	   :
converters#clr-namespace:WorkerHaCS.Converters     5   	     � Title$   ��5	   	   $	��450��6   $	��800��6    � 	Resources 5
      5  /WorkerHaCS.Converters.HouseInformationConverter   HouseInformationConverter,  &WorkerHaCS.Converters.PaymentConverter  PaymentConverter,  &WorkerHaCS.Converters.ServiceConverter  ServiceConverter+  %WorkerHaCS.Converters.StreetConverter  StreetConverter+  %WorkerHaCS.Converters.TenantConverter  TenantConverter,  &WorkerHaCS.Converters.AddressConverter  AddressConverter-  'WorkerHaCS.Converters.DateTimeConverter  DateTimeConverter��%�   &	        &	      &	 &     &	 9     &	 L     &	 _     &	 r       5   
   6/     5   
   6&     5   
   6&     5   
   6%     5   
   6%     5   
   6&     5   
   6'   5      .��5      � .+�5   
   � $��0q�6   $	��420��6   $	��800��6'   .+�5      &   System.Windows.Controls.DataGrid  -   5        $��DebtDataGrid��5      $��10,10,30,20q�6+      AutoGenerateColumns$ False��6@      CanUserAddRows$ False��6\      CanUserDeleteRows$ False��6s      Columns 5      0	  *System.Windows.Controls.DataGridTextColumn	  5      ,
  &System.Windows.Controls.DataGridColumn 
  Header$ Id��6)    
  
Visibility$ Hidden=�6L   1  +System.Windows.Controls.DataGridBoundColumn   Binding 65   �� *Id+6L   	  5      $ Арендатор��6)    6<   �� *
TenantId+	 �� 	Converter#	 [ 
 �� Mode$
 TwoWay=�	  5      $ Услуга��6)    69   �� *	ServiceId+#	 [ $
 TwoWay=�	  5      $ Тариф, руб.��6)    6>   �� *Rate+	  5      $&  Сумма оплаты, руб.��6)    6E   �� *ActuallySpent+	  5      $ Долг, руб.��6)    6=   �� *Debt+	  5      $ Дата оплаты��6)    6>   �� *DateOfPayment+#	 [ $
 TwoWay=�	  5      $ В срок оплата��6)    6@   �� *	PaymentId+#	 [ $
 TwoWay=�5       5!      5"      5#      