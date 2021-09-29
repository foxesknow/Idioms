// IdiomsPlusPlus.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>
#include <string>
#include <vector>
#include <cstdint>
#include <type_traits>
#include <tuple>
#include <algorithm>

struct Idiom124
{
    void run()
    {
        using namespace std;

        vector<int> a{1, 2, 4, 8, 16, 32, 64};
        int index = binarySearch(a, 44); 
    }

template<typename T>
int binarySearch(const std::vector<T> &a, const T &x)
{
    if(a.size() == 0) return -1;

    size_t lower = 0;
    size_t upper = a.size() - 1;

    while(lower <= upper)
    {
        auto mid = (lower + upper) / 2;

        if(x == a[mid])
        {
            return (int)mid;
        }
        else if(x > a[mid])
        {
            lower = mid + 1;
        }
        else
        {
            upper = mid - 1;
        }
    }

    return -1;
}
};

struct Idiom126
{
    auto run()
    {
        return std::make_tuple("Hello", true);
    }
};

struct Idiom272
{
    void run()
    {
        for(int i = 1; i <= 100; i++)
        {
            if((i % 15) == 0) std::cout << "FizzBuzz" << std::endl;
            else if((i % 5) == 0) std::cout << "Buzz" << std::endl;
            else if((i % 3) == 0) std::cout << "Fizz" << std::endl;
            else std::cout << i << std::endl;
        }
    }
};

struct Idiom271
{
    struct foo{};
    struct derived : foo{};

    template<typename T>
    void tst(T)
    {
        using namespace std;

        // Strip away and references and pointer
        typedef remove_const<remove_pointer<decay<T>::type>::type>::type D;

        if(is_same<D, foo>::value)
        {
            cout << "same type" << endl;
        }
        else if(is_base_of<foo, D>::value)
        {
            cout << "extends type" << endl;
        }
        else
        {
            cout << "not related" << endl;
        }
    }

    void run()
    {
        const foo f;
        tst(&f);

        const foo &t = f;
        tst(t);

        tst(1);

        derived d;
        tst(&d);
    }
};

struct Idiom275
{
    void run()
    {
        using namespace std;

        const string s = "111111110000001100001000";
        const auto blocks = s.length() / 8;

        //auto a = new uint8_t[blocks];
        vector<uint8_t> a(blocks);

        for(size_t block = 0; block < blocks; block++)
        {
            uint8_t acc = 0;
            const auto start = block * 8;
            for(size_t offset = start; offset < start + 8; offset++)
            {
                acc = (acc << 1) + (s[offset] - '0');
            }

            a[block] = acc;
        }
    }
};

int main()
{
    Idiom124 idiom;
    idiom.run();

    return 0;
}


