根据一组Type，生成一个文件，文件中包含每个type的序列化器

执行exe时，重定向输出，即可写入指定文档。如：serialize.exe > test.cs

待完成：
1、完成基本内置类型的序列化器代码
2、运行时，根据对象，运行序列化代码
3、数组序列化
4、buffer序列化
5、List, Dictionary序列化
