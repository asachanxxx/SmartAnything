using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace smartOffice.Classes
{
    public class LanguageHandler
    {
        public static string txt_save_success_msg = "Data saved successfully.";
        public static string txt_save_confirm_msg = "Do you want to save ?";
        public static string txt_exit_confirm_msg = "Do you want to exit ?";
        public static string txt_reset_confirm_msg = "Do you want to reset ?";
        public static string txt_sure_exit_confirm_msg = "Are you sure you want to exit ?";
        public static string txt_want_to_process_msg="Do you want to process this ?";
        public static string txt_process_success_msg = "Data processed successfully. ";
        public static string txt_cannot_edit_proccesed_msg = "Cannot edit this PO; It is already processed ";
        public static string txt_confirm_print_msg = "Do you want to Print ?";
        public static string txt_cannot_edit_PO_msg = "Cannot edit this PO; It is already processed ";
        public static string txt_serevr_down_logoff_confirm_msg = "Server is not connected.Do yoi want to logoff?";


        public static string txt_enter_role_id = "Please enter user role ID. ";
        public static string txt_enter_role_description = "Please enter user role description ";
        public static string txt_role_id_fault_error="Entered user role ID has some fault ";
        public static string txt_invalid_user_id_error="Entered user ID is not valid...";
        public static string txt_enter_user_id="Please enter user Id ";


        public static string txt_nodetail_for_emp_id="No details for this employee ID !";
        public static string txt_invalid_emp_id="Invalid employee ID !";

        public static string txt_enter_current_to_add_new_password = "Please enter current password to enter new password ";
        public static string txt_enter_confirm_password = "Please enter confirm password ";
        public static string txt_invalid_user_role_id = "Entered user role ID is not a valid user role ID ";
        public static string txt_current_password_invalid="Current password is incorrect !";
        public static string txt_no_match_password_error="Not match with the password !";
        public static string txt_function_disable = "Function disabled. ";
        public static string txt_enter_telephonr_number = "Please enter telephone number.";
        public static string txt_enter_password = "Please enter password ";
        public static string txt_enter_username_password = "Please enter User Name and Password !";
        public static string txt_invalid_username_password = "The User Name or Password you entered is incorrect !";
        public static string txt_restricted_user = "Restricted User !";
        public static string txt_address_required = "Address is requeired feild";
        public static string txt_data_saved_on = "Data saved on code";
        public static string txt_no_permission_to_edit = "You Do not have Permissions to Edit !";


        public static string txt_enter_wastage_number = "Please enter wastage number ";
        public static string txt_enter_location_field = "Please enter location field ";
        public static string txt_enter_location_id= "Please enter location ID";
        public static string txt_enter_location_name ="Please enter location name";
        public static string txt_enter_wastage_detail_table = "Please enter Wastage Details in the Table ";
        public static string txt_exist_wastage_note_want_update = "Existing Wastage Note ! Do you want to update?";
        public static string txt_invalid_location_select="Entered location is not a valid location ";
        public static string txt_location_id_fault = "Entered location ID has some fault. ";
        public static string txt_enter_location = "Please enter the location ";
        public static string txt_item_code_exists_and_add_another = "Item code is existing in the grid. Do you want to add another item?";
        public static string txt_enter_quantity = "Please enter the quantity";
        public static string txt_stock_less_than_quantity = "Stock is less than entered quantity ";
        public static string txt_enter_cost_price="Please enter cost price ";
        public static string txt_enter_selling_price = "Please enter retail price ";
        public static string txt_enter_ofz_tel_number= "Please enter office telephone number";
        public static string txt_enter_address = "Please enter address.";
        public static string txt_stock_enough="Stock enough";
        public static string txt_stock_not_enough = "Stock not enough";


        public static string txt_enter_source_location = "Please enter the source location";
        public static string txt_destination_source_location = "Please enter the destination location ";
        public static string txt_cannot_edit_proces_tansfer_note_msg = "Can't edit this transfer note.It's already processed.";
        public static string txt_enter_transfer_note_number = "Please enter transfer note number ";
        public static string txt_Prcess_transfer_in = "You don't process the transfer note ";

        public static string txt_enter_transfer_note_number_not_valid = "Entered transfer note number has some fault ";
        public static string txt_enter_source_location_field="Please enter source location field ";
        public static string txt_enter_destination_location_field = "Please enter destination location field ";
        public static string txt_source_location_invalid = "Entered source location is not a valid location ";
        public static string txt_destination_location_invalid = "Entered destination location is not a valid location ";
        public static string txt_exists_transfer_note_want_update="Existing Transfer Note ! Do you want to update?";
        public static string txt_product_id_exists_wand_add_row = "Product id is existing in the grid. Do you want to add another row?";
        public static string txt_invalid_item_code = "Invalid item code !";

        public static string txt_exists_return_no_want_update = "Existing return no ! Do you want to update?";
        public static string txt_enter_rpn_number = "Please enter PRN number ";
        public static string txt_product_code_exists_want_add_new = "Product code is existing in the grid. Do you want to add another item?";
        public static string txt_invalid_supplier_id = "Entered supplier ID is not valid";
        public static string txt_enter_supplier = "Please enter the Supplier ";

        public static string txt_cant_edit_req_alredy_processed = "Can't edit this requisition.It's already processed.";
        public static string txt_req_not_processed = "Can't use this requisition.It's not processed.";
        public static string txt_enter_request_number = "Please enter request number ";
        public static string txt_enter_request_project_details = "Please enter Request product details in the Table ";
        public static string txt_exists_req_number_want_update = "Existing requisition no ! Do you want to update?";
        public static string txt_invalid_product_id = "Invalid Product Id !";
        public static string tst_select_request_data_not_valid = "Selected req date or delivery date not valid ";
        public static string txt_code_alredy_inserter_wish_to_edit = "Code already inserted. Do you wish to edit?";
        public static string txt_select_yes_edit_no = " Select Yes to EDIT/ No to enter the code again in a new line/ Cancel to remain on the same line";
        public static string txt_enter_code = "Please enter code ";
        public static string txt_enter_description = "Please enter description ";
        public static string txt_exists_tax_want_update = "Existing Tax ! Do you want to update?";
        public static string txt_tax_code_has_falult_error = "Entered tax code has some fault ";
        public static string txt_sequence_less_than_text = "Sequence should be less than or equal 10 ";
        public static string txt_tax_rate_less_than_text = "Tax rate should be less than or equal 100";
        public static string txt_enter_rate = "Please enter tax rate";
        public static string txt_req_invalid = "Entered Requisition no is not valid";
        public static string tst_select_req_date_not_valid = "Selected request date is not valid ";
        public static string tst_select_del_date_not_valid = "Selected delivery date is not valid ";




        public static string txt_invalid_key_title = "Invalid Key";
        

        public static string txt_data_saved_on_supplier_id = "Data saved on supplier id";
        public static string txt_enter_supplier_id = "Please enter supplier ID ";
        public static string txt_enter_suplier_name = "Please enter supplier name ";
        public static string txt_exists_suplier_update = "Existing Supplier ! Do you want to update?";
        public static string txt_suplier_id_has_fault = "Entered supplier ID has some fault ";
        public static string txt_invalid_mobile_number = "Entered mobile number is not valid ";
        public static string txt_invalid_home_telephone = "Entered tel home is not valid ";
        public static string txt_invalid_office_telephone = "Entered tel office is not valid. ";
        public static string txt_enter_order_cycle = "Please enter number of date for order cycle ";

        public static string txt_invalid_emamil="e-mail address must be valid e-mail address format.";
        public static string txt_example_email = "(example :'someone@example.com')";
        public static string txt_invalid_fax_number = "Entered fax number is not valid ";
        public static string txt_invalid_nic="Entered NIC is not valid ";

        public static string txt_invalid_sale_assistance_id = "Entered slaes assistance ID has some fault ";
        public static string txt_invalid_sale_assistance_location = "Entered slaes assistance location has some fault ";
        public static string txt_level_save_success_msg = "Level saved successfull.";
        public static string txt_invalid_level_id = "Entered product level ID is not valid";
        public static string txt_enter_level_id = "Please enter level Id";
        public static string txt_exists_level_want_update = "Existing Product Level ! Do you want to update?";
        public static string txt_level_id_has_fault = "Entered product level code has some fault";
        public static string txt_data_saved_id_on = "Data saved on id";

        public static string txt_enter_product_id="Please enter product ID ";
        public static string txt_enter_name_indescription_field = "Please enter product name in description field ";
        public static string txt_exists_product_want_update = "Existing Product ! Do you want to update?";
        public static string txt_default_location_invalid = "Entered default location is not valid location ";
        public static string txt_invalid_parent_product = "Entered parent product ID is not a valid product ";
        public static string txt_product_id_fault = "Entered product ID has some fault ";
        public static string txt_enterd_parent_id_invalid = "Entered parent ID has some fault ";
        public static string txt_enterd_default_location_id_invalid = "Entered default location ID has some fault ";
        public static string txt_invalid_commision_amount = "Entered comission amount is not valid ";
        public static string txt_invalid_commision_per = "Entered comission percentage is not valid ";
        public static string txt_invalid_pack_size = "Entered pack size is not valid ";
        public static string txt_invalid_supplier_price = "Entered supplier price is not valid ";
        public static string txt_invalid_min_price = "Entered min price is not valid ";
        public static string txt_invalid_medium_price = "Entered Medium Price is not valid ";
        public static string txt_invalid_max_price = "Entered max price is not valid ";
        public static string txt_invalid_unit_price = "Entered Unit Price is not valid ";
        public static string txt_invalid_mrp_price = "Entered mrp price is not valid ";
        public static string txt_invalid_cost_price = "Entered Cost Price is not valid ";
        public static string txt_invalid_whole_sale_priice = "Entered whole sale price is not valid ";
        public static string txt_invalid_retail_price = "Entered retail price is not valid ";
        public static string txt_invalid_company_price = "Entered company price is not valid ";
        public static string txt_invalid_default_location = "Entered defult location is not valid location ";
        public static string txt_invalid_sales_assistant_id = "Entered sales assistant ID is not valid";
        public static string txt_exixts_sales_assistant_id_in_grid = "Entered sales assistant ID is curreently exist in the datagrid";
        public static string txt_sales_assistant_id_has_fault = "Entered sales assistance ID has some fault ";
        public static string txt_already_exists_suplier_id = "Entered supplier ID is curreently exist in the datagrid";
        public static string txt_invalid_price_level_id = "Entered price level ID is not valid";
        public static string txt_price_level_currently_exists = "Entered price level ID is curreently exist in the datagrid";
        public static string txt_price_level_id_has_fault = "Entered price level ID has some fault ";
        public static string txt_enter_id = "Please enter ID ";
        public static string txt_existing_price_level_want_update = "Existing Price Level ! Do you want to update?";
        public static string txt_enter_LevelGL_id = "Please enter level for GL ";
        public static string txt_invalid_LevelGL_id = "Entered level id is not valid ";
        public static string txt_enter_control_acc_code = "Please enter control account code "; 
        public static string txt_enter_product_inventry_code = "Please enter product inventory code ";
        public static string txt_enter_acc_code = "Please enter account code ";




        public static string txt_vooucher_save_succes_msg = "Voucher saved successfull.";
        public static string txt_enter_gift_voucher_number = "Please enter gift voucher number.";
        public static string txt_voucher_already_exists = "Gift vouchet number already exists.";
        public static string txt_invalid_voucher_type_id = "Entered gift voucher type Id is not a valid gift voucher type";
        public static string txt_enter_voucher_type = "Enter valid gift voucher type.";
        public static string txt_invalid_create_location_id = "Entered create location is not valid location.";
        public static string txt_enter_allocate_location = "Entered allocate location is not a valid location.";
        public static string txt_voucher_number_has_fault = "Entered gift voucher number has some fault ";
        public static string txt_voucher_type_fault = "Entered gift voucher type has some fault.";
        public static string txt_voucher_create_location_fault = "Entered gift voucher create location has some fault.";
        public static string txt_invalid_quantity = "Invalid quantity selected.";
        public static string txt_allocate_location_fault = "Entered gift voucher allocate location has some fault.";
        public static string txt_invali_expire_date = "Invalid expire dated selected.";

        public static string txt_logout_confirm = "Are you sure you want to Logout ?";
        public static string txt_permission_error_caution_msg = "You do not have permission to edit.";
        public static string txt_permission_coution_error_delete = "You do not have permission to delete.";
        public static string txt_permission_coution_error_print = "You do not have permission to print.";
        public static string txt_permission_coution_error_save ="You do not have permission to save.";
        public static string txt_data_saved_on_id = "Data saved on location id";
        public static string txt_invalid_role_id = "Entered user role ID is not valid.";
        public static string txt_exists_location_wonna_update = "Existing Location ! Do you want to update?";

        public static string txt_common_error_msg = "Oops! Something goes wrong.Please try again later.";

        public static string txt_caution = "Caution";
        public static string txt_logout = "Logout";
        public static string txt_exit = "Exit";
        public static string txt_exception = "Exception";
        public static string txt_confirm = "Confirm";
        public static string txt_error = "Error";
        public static string txt_success = "Success";
        public static string txt_information = "Information";
        public static string txt_print = "Print";

        public static string txt_enter_customer_id = "Please enter customer Id.";
        public static string txt_enter_customer_name = "Please enter customer name ";
        public static string txt_exists_custoomer_want_update = "Existing customer ! Do you want to update?";
        public static string txt_invalid_category_type = "Entered customer category type Id is not a valid category type ";
        public static string txt_category_id_has_fault="Entered customer category id has some fault ";
        public static string txt_enter_customer_category_id = "Please enter customer category ID.";
        public static string txt_customer_id_has_fault="Entered customer id has some fault.";
        public static string txt_invalid_birthday= "Selected B'Day is not a valid B'Day ";
        public static string txt_invalid_wedding_anivaasary = "Selected Wedding Anivaersary is not a valid ";
        public static string txt_invalid_customer_category_id="Data saved on customer category id.";
        public static string txt_enter_discount_percentage="Please enter discount percentage";
        public static string txt_enter_points = "Please enter points.";
        public static string txt_exists_category_want_update="Existing customer category ! Do you want to update?";
        public static string txt_invalid_discount_percentage = "Entered discount percentage is not valid.";
        public static string txt_discount_percent_less_than="Discount percentage should be less than 100 ";
        public static string txt_invalid_points = "Entered point is not valid.";
        public static string txt_points_less_than = "Points should be less than 100.";

        public static string txt_exists_voucher_type_want_update = "Existing gift voucher type ! Do you want to update?";
        public static string txt_enter_voucher_type_id = "Please enter gift voucher type Id";
        public static string txt_enter_Gift_voucher_no = "Please enter gift voucher no";
        public static string txt_enter_valid_amount = "Please enter vaid amount";
        public static string txt_voucher_type_id_falult = "Entered gift voucher type ID has some fault ";
        public static string txt_invalid_price_amount="Enter valid price amount";
        public static string txt_exists_product_level_want_update = "Existing Product Level ! Do you want to update?";
        public static string txt_enter_level_description = "Please enter level description.";
        public static string txt_enter_order_number = "Please enter order number.";
        public static string txt_enter_product_level_id_fault = "Entered product level has some fault";
        public static string txt_fill_level_id = "Please fill the level id.";
        public static string txt_pls_eneter_batch_no = "Please enter batch number.";
        public static string txt_enter_voucher_starting_number = "Please enter starting number.";
        public static string txt_enter_voucher_quantity="Please enter gift voucher quantity.";
        public static string txt_invalid_exp_date = "Invalid expire date select.";
        public static string txt_enter_create_location = "Please select create location.";
        public static string txt_enter_allocate_location_invalid = "Please select allocate location.";
        public static string txt_invalid_batch_no = "Invalid batch number.";
        public static string txt_invalid_starting_number = "Invalid starting number.";
        public static string txt_minimum_starting_number = "Minimum number for strat number is 1.";
        public static string txt_enter_valid_quantity = "Please enter valid quantity.";
        public static string txt_minimum_number_quantity = "Minimum number for quantity is 1.";
        public static string tx_cant_edit_exists_voucher = "Can\'t edit exists gift voucher.";
        public static string txt_enter_valid_code = "Please enter valid code.";
        public static string txt_exists_pay_mode_want_update = "Existing Pay mode ! Do you want to update?";
        public static string txt_fil_this_field = "Please fill this filed";
        public static string txt_pay_mode_description = "Existing pay mode description.";
        

        public static string txt_enter_sales_assistance_id = "Please enter sales assistant ID ";
        public static string txt_enter_sales_assistance_name = "Please enter sales assistant name ";
        public static string txt_enter_sales_assistance_nic = "Please enter sales assistant NIC ";
        public static string txt_exists_sal_ass_want_update = "Existing Sales Assistant ! Do you want to update?";
        public static string txt_invalid_order_quantity="Orderd Quantity is less than entered quantity ";

        public static string txt_enter_promotion_Type_id = "Please enter promotion type ID ";
        public static string txt_promotion_Type_id_fault = "Entered promotion type id has some fault.";
        public static string txt_exists_promotion_type_want_update = "Existing Promotion type ! Do you want to update?";


        public static string txt_enter_bill_promotion_id = "Please enter bill value promotion ID ";
        public static string txt_bill_promotion_id_has_fault = "Entered bill promotion id has some fault.";
        public static string txt_exists_bill_promotion_want_update = "Existing Promotion ! Do you want to update?";
        public static string txt_enter_bill_promotion_name = "Please enter bill value promotion name ";
        public static string txt_days_not_correct = "Days should be equal to";
        public static string txt_enter_discount = "Please enter discount amount or discount percentage";

        public static string txt_enter_Product_promotion_grid_detail = "Please enter Promotion product details in the Table ";
        public static string txt_product_promotion_id_has_fault = "Entered product promotion id has some fault.";
        public static string txt_promotion_already_created = "You have already created this product promotion ";
        public static string txt_enter_value = "Please enetr the value";
        public static string txt_promotion_already_created_daterange = "You have already created this product promotion within this date and time range ";

        public static string txt_enter_product_promotion_id = "Please enter product promotion ID ";
        public static string txt_enter_product_promotion_name = "Please enter product promotion name ";
        public static string txt_invalid_location_id = "entered location id is not a valid location ";
        public static string txt_enter_transfer_detail_table = "please enter transfer products details in the table";

        public static string txt_enter_usage_note_number = "Please enter staff usage note number";
        public static string txt_enter_usage_detail_table = "please enter staff usage products details in the table";

        public static string txt_cannot_edit_proces_usage_note_msg = "Can't edit this staff usage note.It's already processed.";
        public static string txt_exists_usage_note_want_update = "Existing staff usage Note ! Do you want to update?";

        public static string txt_enter_item_main_id = "Please enter main item ID";
        public static string txt_enter_created_qty = "Please enter quantity you want create";
        public static string txt_enter_subitem_qty = "Please enter quantity per one pack";
        public static string txt_enter_item_sub_id_exist = "entered sub item code already exist in the table";
        public static string txt_enter_selling_price_not_valid = "entered selling price is less than the cost price";
        public static string txt_enter_valid_selling_price = "please enetr valid selling price";

        public static string txt_exists_po_want_update = "Existing Purchase order ! Do you want to update?";
        public static string txt_enter_po_table = "please enter order products details in the table";
        public static string txt_edit_yes_no = "Code already inserted. Do you wish to edit?"+
                                               "Select Yes to EDIT/ No to remain on the same line";

        public static string txt_enter_po_number = "Please enter purchase order number";

        public static string txt_enter_payMode_Id = "Please enter pay mode";
        public static string txt_enter_Sub_payMode_code = "Please enter sub pay mode code";
        public static string txt_enter_Sub_payMode_description = "Please enter sub pay mode description";

        public static string txt_enter_grn_number = "Please enter good received note number";
        public static string txt_enter_grn_table = "please enter products details in the table";

        public static string txt_enter_grn_ref_number = "Please enter good received note number or reference number";

        public static string txt_want_to_print_msg = "Do you want to print this data?";


        public static string txt_po_already_exists = "Already exists purchase order number.";
    }


}
