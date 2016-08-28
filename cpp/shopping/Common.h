#ifndef _COMMON_H_
#define _COMMON_H_

#include <ctime>
#include <memory>
#include <queue>
#include <thread>
#include <vector>

using namespace std;

class Customer;
class ShopQueue;
class Cashier;
class ShopManager;

typedef shared_ptr<Customer> TPtrCustomer;
typedef queue<TPtrCustomer> TQueue;
typedef shared_ptr<ShopQueue> TPtrShopQueue;
typedef shared_ptr<Cashier> TPtrCashier;
typedef vector<TPtrCashier> TCashierVec;
typedef shared_ptr<thread> TPtrThread;
typedef vector<TPtrThread> TThreadVec;
typedef shared_ptr<ShopManager> TShopManager;

#endif
