insert into book_borrowing_log
    (book_no, user_no, expire_at)
values
    ("E0094868", "3112005816", date("now", "+3 months")),
    ("A1840127", "3112005816", date("now", "+3 months"));

insert into book_borrowing_log
    (book_no, user_no, expire_at, returned_at)
values
    ("A0836869", "3112005816", date("now", "+3 months"), date("now", "+1 months"));
