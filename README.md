# ECOMMERCE PLATFORM

####  The purpose of e-commerce platform is selling electronic products. It allows to manage products in the warehouse (add, modify, delete), sell them and send them to customers.

### Important:
1. This repository contains only implementation of one domain: Sales
2. Below you will find event storming session for all subdomains discovered


## Product Management
Products from the following categories are sold on the platform: Audio, Telephones, TV. The system user can add any number of products and assign it to the appropriate categories. Each product can be modified and removed from the system at any time.

## Customer Management
The CRM module is responsible for customer management. In this module you can add new customers, change their data, delete, mark as debtors and as VIPs.

## Sales
1. Customers can make purchases on the e-commerce platform. To make this happen, an order is created to which products are added:
   - There are no limits on the number of products on the order
   - Orders can only be created for active customers
   - The order contains customer data and information about added products

2.	For customers who have placed orders for a total amount of over PLN 1,000, a standard discount applies: 5%. This discount is valid for all products that are on the order. If the customer has been marked as VIP in the CRM module, then the discount granted is 10%. Discounts cannot be combined.

3.	When the order is completed, it is accepted. An invoice is issued for the accepted order. The order can be accepted when:
   - Created not later than a month ago
   - The customer is not a debtor.
   - VIP customers are an exception: for such customers we do not check whether they are debtors and the expiry date of the order does   not apply

4.	When the invoice is issued, the tax for the order is calculated. The tax for each product is 10%. The exceptions are telephones. Telephones are taxed at 15%. The above taxes do not apply to foreigners. For foreign customers, all products are taxed at 10%.

## Shipping orders
After accepting the order and issuing the invoice, the products are immediately sent to the customer
