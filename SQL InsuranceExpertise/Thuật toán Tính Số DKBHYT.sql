----Thuật toán Cập nhật Số ĐKBHYT trên bảng BHYT
//Chú ý: Mỗi năm cần khởi tạo giá trị STT_BHYT đầu tiên 1 lần


--Alter table bhyt add stt_dkbhyt text;
--CREATE INDEX bhyt_stt_dkbhyt_idx ON bhyt USING btree (stt_dkbhyt);



-- Số ĐK BHYT tự sinh có cấu trúc gồm: số năm_STT (từ 1 đến n),ko phụ thuộc vào khoa, không phụ thuộc vào lần cập nhật thẻ BH
---Lấy Max stt_dkbhyt
SELECT (MAX(cast(substr(stt_dkbhyt, 6, char_length(stt_dkbhyt)) as numeric))+1) as value_stt 
from bhyt where bhytcode<>'' and stt_dkbhyt is not null and substr(stt_dkbhyt, 6, char_length(stt_dkbhyt))<>'';
--//Lay danh sach can cap nhat STT
SELECT bh.bhytid,to_char(bhytdate, 'yyyy') as year_bhytid FROM (select bhytid,bhytdate from bhyt where bhytcode<>'' and (stt_dkbhyt is null or stt_dkbhyt='')) bh inner join (select bhytid,vienphiid,vienphidate from vienphi where doituongbenhnhanid=1 and loaivienphiid=0 and vienphidate >= '2017-01-01 00:00:00') vp on vp.bhytid=bh.bhytid order by bh.bhytdate;

---Cap nhat STT_BHYT
UPDATE bhyt SET stt_dkbhyt=to_char(bhytdate, 'yyyy') || '_' || (SELECT (MAX(cast(substr(stt_dkbhyt, 6, char_length(stt_dkbhyt)) as numeric))+1) as value_stt from bhyt where bhytcode<>'' and stt_dkbhyt is not null and substr(stt_dkbhyt, 6, char_length(stt_dkbhyt))<>'' and to_char(bhytdate, 'yyyy')='" + year_bhytid + "') WHERE bhytid='" + bhytid + "';















