#include <cstdlib>
#include <iostream>

#include "Customer.h"
#include "CustomerMaker.h"
#include "ShopManager.h"
#include "ShopQueue.h"

CustomerMaker::CustomerMaker(TShopManager sm) : sm(sm) {
   srand (time(NULL));
}

void CustomerMaker::Run() {

  if (rand()%100<50) {return;}

  TPtrCustomer c(new Customer());
  c->SetNumItems(rand()%20);
  sm->Add(c);

  cout << "New customer: " << *c << endl;
}
