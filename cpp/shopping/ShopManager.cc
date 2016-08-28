#include <algorithm>
#include <functional>

#include "Cashier.h"
#include "ShopManager.h"
#include "ShopQueue.h"

ShopManager::ShopManager() : isRunning(false),
                             cashiers(TCashierVec()) {
  //threads(TThreadVec()) {
}

ShopManager::~ShopManager() {
  isRunning = false;

  for(TCashierVec::iterator it = cashiers.begin(); it!=cashiers.end(); ++it) {
    (*it)->SetIsRunning(false);
  }

  //for (TThreadVec::iterator it = threads.begin(); it!=threads.end(); ++it) {
  //  (*it)->join();
  //}
}

void ShopManager::Add(TPtrCustomer c) {

  if (cashiers.size()==0) {
    cout << "creating initial cashier" << endl;
    TPtrShopQueue q(new ShopQueue);
    TPtrCashier cashier(new Cashier(to_string(0),q));
    cashiers.push_back(cashier);
  }

  if (cashiers.size()>1) {
    cashiers.erase(remove_if(cashiers.begin(), cashiers.end(), 
                             [](TPtrCashier i) { return !i->IsProcessing(); }), cashiers.end());
  }

  TPtrCashier cashier;// = *(cashiers.begin());
  unsigned int maxLength = 5;

  cout << "searching for cashier" << endl;
  for(TCashierVec::iterator it = cashiers.begin(); it!=cashiers.end(); ++it) {
    unsigned int l = (*it)->GetLength();
    if (l<=maxLength && (!cashier || l<cashier->GetLength())) {
      cashier = (*it);
    }
  }

  if (!cashier) {
    cout << "no cashier found. creating new cashier" << endl;
    TPtrShopQueue q(new ShopQueue);
    unsigned int id = cashiers.size();
    cashier = make_shared<Cashier>(Cashier(to_string(id),q));
    cashiers.push_back(cashier);
  }

  cout << "assigning customer to cashier: " << *cashier << endl;

  //pick least busy cashier
  cashier->Enqueue(c);

}

void ShopManager::Run(struct tm now) {

//make all cashiers do there work

  isRunning = true;

  for(TCashierVec::iterator it = cashiers.begin(); it!=cashiers.end(); ++it) {
    (*it)->Run(now);
  }

  /*if (cashiers.size()==0) {
    TPtrShopQueue q(new ShopQueue);
    TPtrCashier cashier(new Cashier(q));
    cashiers.push_back(cashier);

    TPtrThread t(new thread(CashierWorker,cashier));
    threads.push_back(t);
    }*/

}

/*void CashierWorker(TPtrCashier ca) {
  cout << "starting cashier worker..." << endl;
  while (ca->IsRunning()) {
  time_t t = time(0);   // get time now
  struct tm * now = localtime( & t );

  ca->Run(*now);

  this_thread::sleep_for(1s);
  }
  cout << "ending cashier worker..." << endl;
  }*/
