bước 1: download file demo_sum.zip(file visual studio code)
bước 2: download file demo_websever(file sql)
bước 3: run file demo_sum
bước 4: mở cmd nhập lệnh:
curl -X POST https://localhost:7021/api/tinhtong 
-H "Content-Type: application/json" 
-d "{\"soA\": ,\"soB\":  }"  \\ ví dụ: -d "{\"soA\": 10 ,\"soB\": 8 }"
