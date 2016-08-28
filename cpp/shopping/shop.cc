#include <chrono>
#include <ctime>
#include <iostream>
#include <thread>

#include "Customer.h"
#include "ShopQueue.h"
#include "CustomerMaker.h"
#include "Cashier.h"
#include "ShopManager.h"

using namespace std;
using namespace std::literals;

void CustomerWorker();
void ShopWorker();

TPtrShopQueue que;
TShopManager sm;
bool isRunning;

int main(int argc, char *argv[]) {

  cout << "Shopping..." << endl;

  //que = make_shared<ShopQueue>();
  sm = make_shared<ShopManager>();
  isRunning = true;

  thread tCustomer(CustomerWorker);
  thread tCashier(ShopWorker);//CashierWorker);

  //TPtrCustomer c1(new Customer());

  //que->Add(c1);
  /*TPtrCustomer p1 = que->Process();
    if (p1) {
    cout << "got customer " << *p1 << endl;
    }
    TPtrCustomer pend = que->Process();
    if (!pend) {
    cout << "got no customer" << endl;
    }*/

  cout << "Running... hit enter to quit..." << endl;
  cin.ignore();

  isRunning = false;

  cout << "stopping..." << endl;
  tCustomer.join();
  cout << "...customer thread done..." << endl;
  tCashier.join();
  cout << "...cashier thread done..." << endl;

  return 0;
}

void CustomerWorker() {
  CustomerMaker cm = CustomerMaker(sm);

  cout << "starting customer worker..." << endl;
  while(isRunning) {
    cm.Run();

    this_thread::sleep_for(2s);
  }
  cout << "ending customer worker..." << endl;
}

void ShopWorker() {

  cout << "starting cashier worker..." << endl;
  while (isRunning) {
    time_t t = time(0);   // get time now
    struct tm * now = localtime( & t );

    sm->Run(*now);

    this_thread::sleep_for(1s);
  }
  cout << "ending cashier worker..." << endl;
}

