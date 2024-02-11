import {usePostRequest} from "@/hooks/usePostRequest";
import {useDebounce} from '@/hooks/useDebounce';
import {parseObj} from '@/utils/helperFunctions';
import {Autocomplete} from '@mui/joy';
import {MutationFunction} from '@tanstack/react-query';

import React from 'react';

export default function CustomAutocomplete(
    {
        keyField,
        labelField,
        requestParams,
        mutationFn,
        mutationKeyName,
        requestParamsName,
        placeholder,
        dataPlace,
        onChange,
        defaultValue,
        filterFn,
        variant,
        sx,
        ...props
    }: {
        defaultValue?: {};
        keyField: string;
        onChange: (value: any) => void;
        labelField: string;
        mutationFn: MutationFunction<any, void>;
        mutationKeyName: string;
        requestParams: Object;
        variant?: 'plain' | 'outlined';
        requestParamsName?: string;
        placeholder?: string;
        props?: any;
        dataPlace: string;
        sx?: any;
        filterFn?: (value: any, index: number, array: any[]) => boolean;
    }) {
    const [input, setInput] = React.useState('');
    const debouncedJobSiteName = useDebounce<string>(input, 300);

    const [optionList, setOptionList] = React.useState([defaultValue]);

    const data = usePostRequest({
        mutationKey: [mutationKeyName, debouncedJobSiteName],
        mutationFn: mutationFn,
    });

    React.useEffect(() => {
        let params: any = requestParams;
        if (input && requestParamsName) {
            params[requestParamsName] = input;
        }
        data.mutate(params);
    }, [debouncedJobSiteName]);

    React.useEffect(() => {
        if (data.isSuccess) {
            setOptionList([...parseObj(dataPlace, data.data?.data), defaultValue]);
        }
    }, [data.status]);

    return (
        <Autocomplete
            {...props}
            defaultValue={defaultValue}
            onChange={(e, v, r, d) => {
                onChange(v);
            }}
            sx={sx ? sx : {}}
            variant={variant ? variant : 'outlined'}
            getOptionLabel={(option) => parseObj(labelField, option)}
            size="sm"
            autoHighlight
            placeholder={placeholder}
            isOptionEqualToValue={(option: any, value: any) =>
                parseObj(keyField, option) === parseObj(keyField, value)
            }
            filterOptions={(options: any[], state) => {
                const filteredArr: any[] = options.filter((option) =>
                    parseObj(labelField, option)
                        .toLowerCase()
                        .includes(state.inputValue.toLowerCase())
                );
                return filterFn ? filteredArr.filter(filterFn) : filteredArr;
            }}
            onInputChange={(event, value, reason) => {
                setInput(value);
            }}
            options={optionList}
        />
    );
}
